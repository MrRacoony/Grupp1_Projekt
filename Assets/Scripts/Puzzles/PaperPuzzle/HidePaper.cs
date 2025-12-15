using UnityEngine;

public class HidePaper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("start");
        //MonsterScript monster = FindFirstObjectByType<MonsterScript>();
        //monster.StartCoroutine(monster.TutorialAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
