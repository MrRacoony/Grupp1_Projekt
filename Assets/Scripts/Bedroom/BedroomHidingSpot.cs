using UnityEngine;
using UnityEngine.SceneManagement;

public class BedroomHidingSpot : MonoBehaviour
{

    //[SerializeField] private GameObject exitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "BedHiding")
        {
            Debug.Log(GameObject.Find("Monster"));
            GameObject monster = GameObject.Find("Monster");
            monster.GetComponent<MonsterScript>().SetIsHiding(true);
        }
        else
        {            
            
        }
    }
}
