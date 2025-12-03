using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public List<GameObject> taggedObjects = new List<GameObject>();

    [SerializeField] SoundManager.Sound monsterSound;
    [SerializeField] private GameObject leaveButton;    // assign in Inspector

    public float maxSpawnTime = 90;
    public float minSpawnTime = 30;

    public float startAttackTimer = 10;
    private bool startAttack = false;
    [SerializeField] private float attackTrigger;
    [SerializeField] private bool tutorialAttack = true;

    private bool isHiding;

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
            StartCoroutine(TutorialAttack());
        }
    }

    void Update()
    {
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
        SoundManager.PlaySound(monsterSound);
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
        SoundManager.SetVolume(monsterSound, 0);
        SoundManager.PlaySound(monsterSound);

        // Step 1: Increase volume until normal cap
        while (SoundManager.GetVolume(monsterSound) < normalMaxVolume && !isHiding)
        {
            SoundManager.SetVolume(monsterSound, SoundManager.GetVolume(monsterSound) + volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        // Step 2: If hiding, allow volume to max
        while (isHiding && SoundManager.GetVolume(monsterSound) < hidingMaxVolume)
        {
            SoundManager.SetVolume(monsterSound, SoundManager.GetVolume(monsterSound) + volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        // Step 3: Reduce volume back down to 0
        while (SoundManager.GetVolume(monsterSound) > 0f)
        {
            SoundManager.SetVolume(monsterSound, SoundManager.GetVolume(monsterSound) + volumeChangeSpeed * Time.deltaTime);
            yield return null;

            // Show leave button once volume is low enough
            if (SoundManager.GetVolume(monsterSound) <= 0.2f && leaveButton != null)
            {
                leaveButton.SetActive(true);
            }
        }

        SoundManager.StopSound(monsterSound);
    }

    public void OnLeaveButtonPressed()
    {
        // Fail if leaving too early or not hiding
        if (!isHiding || SoundManager.GetVolume(monsterSound) > 0.2f)
        {
            SceneController.LoadScene("Menu"); // fail scene
        }
    }
}