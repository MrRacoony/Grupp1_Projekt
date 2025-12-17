using UnityEngine;

public class ScaryEventManager : MonoBehaviour
{

    [SerializeField] private float minTime = 45.0f;
    [SerializeField] private float maxTime = 60.0f;
    private float targetTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(targetTime > 0f) {
            targetTime -= Time.deltaTime;
            if(targetTime <= 0f) {
                transform.GetChild(0).gameObject.SetActive(true);
            } 
        }
        
    }
}
