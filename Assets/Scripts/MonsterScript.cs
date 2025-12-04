using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterScript : MonoBehaviour
{
    public List<GameObject> taggedObjects = new List<GameObject>();
    public List<string> hidingSpots = new List<string>();
    [SerializeField] private GameObject leaveButton;
    [SerializeField] private string activeSceneName;

    public float maxSpawnTime = 90;
    public float minSpawnTime = 30;

    [SerializeField] private float attackTrigger;
    [SerializeField] private bool tutorialAttack = true;

    [SerializeField] private bool isHiding;
    [SerializeField] private bool attacking = false;

    // Volume settings
    [SerializeField] private float safeMaxVolume = 0.5f;
    [SerializeField] private float hidingMaxVolume = 1.0f;
    [SerializeField] private float volumeChangeSpeed = 0.5f;
    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        attackTrigger = Random.Range(minSpawnTime, maxSpawnTime);
        if (tutorialAttack)
        {
            //StartCoroutine(TutorialAttack());
        }
    }

    void Update()
    {
        Debug.Log(Mathf.Round(SoundManager.GetVolume(SoundManager.Sound.Monster) * 100) / 100);
        AmIHiding();
        if (taggedObjects.Count == 0)
        {
            SceneController.OpenSceneAddition(SceneManager.GetActiveScene().name);
        }
        if (!tutorialAttack)
        {
            
            if (attackTrigger < 0 && !attacking)
            {
                attacking = true;
                attackTrigger = 0;
                StartCoroutine(StartAttack());
            }
            else if (!attacking)
            {
                attackTrigger -= Time.deltaTime;
            }
        }
    }

    void MonsterAttack()
    {
        attackTrigger = Random.Range(minSpawnTime, maxSpawnTime);
        if (!AmIHiding())
        {
            SceneController.LoadScene("Menu"); // fail state
        }
    }

    public bool AmIHiding()
    {
        foreach(string scene in hidingSpots)
        {
            if (activeSceneName == scene)
            {
                isHiding = true;
                return isHiding;
            }
            
        }

        isHiding = false;
        return isHiding;
    }

    public void MonsterScene(string currentScene)
    {
        activeSceneName = currentScene;
    }

    public void SetLeaveButton(GameObject button)
    {
        leaveButton = button;
    }

    public IEnumerator TutorialAttack()
    {
        // Disable colliders on tagged objects
        foreach (GameObject obj in taggedObjects)
        {
            Collider2D col = obj.GetComponent<Collider2D>();
            if (col != null) col.enabled = false;
        }

        //Sound here
        SoundManager.SetVolume(SoundManager.Sound.Monster, 0);
        SoundManager.PlaySound(SoundManager.Sound.Monster);

        // Step 1: Increase volume until normal cap
        while ((Mathf.Round(SoundManager.GetVolume(SoundManager.Sound.Monster) * 100) / 100) < safeMaxVolume || !AmIHiding())
        {
            Debug.Log("step 1");
            SoundManager.SetVolume(SoundManager.Sound.Monster, SoundManager.GetVolume(SoundManager.Sound.Monster) + volumeChangeSpeed * Time.deltaTime);
            if ((Mathf.Round(SoundManager.GetVolume(SoundManager.Sound.Monster) * 100) / 100) >= safeMaxVolume)
            {
                Debug.Log(Mathf.Round(SoundManager.GetVolume(SoundManager.Sound.Monster) * 10) / 10);
                SoundManager.SetVolume(SoundManager.Sound.Monster, safeMaxVolume);
                
            }
            yield return null;
        }

        // Step 2: If hiding, allow volume to max
        while (AmIHiding() && (Mathf.Round(SoundManager.GetVolume(SoundManager.Sound.Monster) * 100) / 100) < hidingMaxVolume)
        {
            Debug.Log("step 2");
            if (leaveButton == null)
            {
                SetLeaveButton(GameObject.Find("BackButton"));
            }
            else if (leaveButton.activeSelf == true)
            {
                Debug.Log(leaveButton);
                leaveButton.SetActive(false);
            }


            SoundManager.SetVolume(SoundManager.Sound.Monster, SoundManager.GetVolume(SoundManager.Sound.Monster) + volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        // Step 3: Reduce volume back down to 0
        while ((Mathf.Round(SoundManager.GetVolume(SoundManager.Sound.Monster) * 100) / 100) > 0f)
        {
            Debug.Log("step 3");
            SoundManager.SetVolume(SoundManager.Sound.Monster, SoundManager.GetVolume(SoundManager.Sound.Monster) - volumeChangeSpeed * Time.deltaTime);
            yield return null;

            // Show leave button once volume is low enough
            if ((Mathf.Round(SoundManager.GetVolume(SoundManager.Sound.Monster) * 100) / 100) <= 0.2f && leaveButton != null)
            {
                leaveButton.SetActive(true);
            }
            foreach (GameObject obj in taggedObjects)
            {
                Collider2D col = obj.GetComponent<Collider2D>();
                if (col != null) col.enabled = true;
            }
        }

        SoundManager.StopSound(SoundManager.Sound.Monster);
        tutorialAttack = false;
        Debug.Log("tutorial done");
    }

    public IEnumerator StartAttack()
    {

        //Sound here
        SoundManager.SetVolume(SoundManager.Sound.Monster, 0);
        SoundManager.PlaySound(SoundManager.Sound.Monster);

        //Build up music
        while ((Mathf.Round(SoundManager.GetVolume(SoundManager.Sound.Monster) * 100) / 100) < hidingMaxVolume)
        {
            Debug.Log("Incomming!");
            SoundManager.SetVolume(SoundManager.Sound.Monster, SoundManager.GetVolume(SoundManager.Sound.Monster) + volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }
        if (!AmIHiding())
        {
            SoundManager.PlaySound(SoundManager.Sound.MonsterScream);
            tutorialAttack = true;
            SceneManager.LoadScene("Menu");
        }
        while ((Mathf.Round(SoundManager.GetVolume(SoundManager.Sound.Monster) * 100) / 100) > 0f)
        {
            Debug.Log("");
            SoundManager.SetVolume(SoundManager.Sound.Monster, SoundManager.GetVolume(SoundManager.Sound.Monster)- volumeChangeSpeed * Time.deltaTime);
            yield return null;

            // Show leave button once volume is low enough
            if ((Mathf.Round(SoundManager.GetVolume(SoundManager.Sound.Monster) * 100) / 100) <= 0.2f && leaveButton != null)
            {
                leaveButton.SetActive(true);
            }
            foreach (GameObject obj in taggedObjects)
            {
                Collider2D col = obj.GetComponent<Collider2D>();
                if (col != null) col.enabled = true;
            }
        }
        // Step 3: Reduce volume back down to 0

        attackTrigger = Random.Range(minSpawnTime, maxSpawnTime);
        attacking = false;
        SoundManager.StopSound(SoundManager.Sound.Monster);
    }
    public void OnLeaveButtonPressed()
    {
        // Fail if leaving too early or not hiding
        if (!AmIHiding() || (Mathf.Round(SoundManager.GetVolume(SoundManager.Sound.Monster) * 100) / 100) > 0.2f)
        {
            SceneController.LoadScene("Menu"); // fail scene
        }
    }
}