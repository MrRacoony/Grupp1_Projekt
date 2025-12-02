using JetBrains.Annotations;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    [SerializeField] SoundManager.Sound monsterSound;
    public float maxSpawnTime = 90;
    public float minSpawnTime = 30;

    public float startAttackTimer = 10;
    private bool startAttack = false;
    [SerializeField] private float attackTrigger;

    private bool isHiding;

    void Start()
    {
        attackTrigger = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        attackTrigger -= Time.deltaTime;
        if (attackTrigger <= startAttackTimer && startAttack == false)
        {
            startAttack = true;
            StartAttacking();
        }
        if (attackTrigger <= 0)
        {
            MonsterAttack();
        }

    }

    void MonsterAttack()
    {
        Debug.Log("Monster Spawned");
        attackTrigger = Random.Range(minSpawnTime, maxSpawnTime);
        if(!isHiding) {
            SceneController.LoadScene("Menu");
        }
    }

    public void SetIsHiding(bool input) {
        isHiding = input;
    }

    private void StartAttacking()
    {
        SoundManager.PlaySound(monsterSound);
    }
}
