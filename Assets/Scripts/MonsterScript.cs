using JetBrains.Annotations;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public float maxSpawnTime = 90;
    public float minSpawnTime = 30;
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

}
