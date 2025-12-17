using UnityEngine;

public class ScaryEventManager : MonoBehaviour
{

    private float minTime = 10.0f;
    private float maxTime = 15.0f;
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
                SoundManager.PlaySound(SoundManager.Sound.DoorCreak);
            } 
        }
        
    }
}
