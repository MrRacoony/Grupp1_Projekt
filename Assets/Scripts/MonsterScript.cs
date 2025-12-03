using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterScript : MonoBehaviour
{
    public List<GameObject> taggedObjects = new List<GameObject>();
    [SerializeField] private GameObject leaveButton;    // assign in Inspector

    public float maxSpawnTime = 90;
    public float minSpawnTime = 30;

    public float startAttackTimer = 10;
    private bool startAttack = false;
    [SerializeField] private float attackTrigger;
    [SerializeField] private bool tutorialAttack = true;

    [SerializeField] private bool isHiding;

    // Volume settings
    [SerializeField] private float normalMaxVolume = 0.5f;
    [SerializeField] private float hidingMaxVolume = 1.0f;
    [SerializeField] private float volumeChangeSpeed = 0.5f;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
        if (taggedObjects.Count == 0)
        {
            SceneController.OpenSceneAddition(SceneManager.GetActiveScene().name);
        }
        if (!tutorialAttack)
        {
            attackTrigger -= Time.deltaTime;
            if (attackTrigger <= startAttackTimer && !startAttack)
            {
                startAttack = true;
                StartAttacking();
            }
            if (attackTrigger <= 0)
            {
                MonsterAttack();
            }
        }
    }

    void MonsterAttack()
    {
        Debug.Log("Monster Spawned");
        attackTrigger = Random.Range(minSpawnTime, maxSpawnTime);
        if (!isHiding)
        {
            SceneController.LoadScene("Menu"); // fail state
        }
    }

    public void SetIsHiding(bool input)
    {
        isHiding = input;
    }

    public void SetLeaveButton(GameObject button)
    {
        leaveButton = button;
    }

    private void StartAttacking()
    {
        SoundManager.PlaySound(SoundManager.Sound.Monster);
    }

    public IEnumerator TutorialAttack()
    {
        Debug.Log("Attacking!");
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
        while (SoundManager.GetVolume(SoundManager.Sound.Monster) < normalMaxVolume && !isHiding)
        {
            Debug.Log("Im at " + SoundManager.GetVolume(SoundManager.Sound.Monster));
            SoundManager.SetVolume(SoundManager.Sound.Monster, SoundManager.GetVolume(SoundManager.Sound.Monster) + volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        // Step 2: If hiding, allow volume to max
        while (isHiding && SoundManager.GetVolume(SoundManager.Sound.Monster) < hidingMaxVolume)
        {
            Debug.Log("sneaky sneaky");
            if (leaveButton == null)
            {
                SetLeaveButton(GameObject.Find("Leave"));
            }
            if (leaveButton.activeSelf == true)
            {
                Debug.Log(leaveButton);
                leaveButton.SetActive(false);
            }
                
            SoundManager.SetVolume(SoundManager.Sound.Monster, SoundManager.GetVolume(SoundManager.Sound.Monster) + volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        // Step 3: Reduce volume back down to 0
        while (SoundManager.GetVolume(SoundManager.Sound.Monster) > 0f)
        {
            SoundManager.SetVolume(SoundManager.Sound.Monster, SoundManager.GetVolume(SoundManager.Sound.Monster) + volumeChangeSpeed * Time.deltaTime);
            yield return null;

            // Show leave button once volume is low enough
            if (SoundManager.GetVolume(SoundManager.Sound.Monster) <= 0.2f && leaveButton != null)
            {
                leaveButton.SetActive(true);
            }
        }

        SoundManager.StopSound(SoundManager.Sound.Monster);
    }

    public void OnLeaveButtonPressed()
    {
        // Fail if leaving too early or not hiding
        if (!isHiding || SoundManager.GetVolume(SoundManager.Sound.Monster) > 0.2f)
        {
            SceneController.LoadScene("Menu"); // fail scene
        }
    }
}