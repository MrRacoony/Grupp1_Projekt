using JetBrains.Annotations;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public float maxSpawnTime = 90;
    public float minSpawnTime = 30;
    [SerializeField] private float attackTrigger;
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
            Debug.Log("Monster Spawned");
            attackTrigger = Random.Range(minSpawnTime, maxSpawnTime);
        }

    }
}
