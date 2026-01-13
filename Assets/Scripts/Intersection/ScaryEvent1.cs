using UnityEngine;

public class ScaryEvent1 : MonoBehaviour
{

    [SerializeField] private GameObject doorCollider;

    private bool hasHappened;
    private bool timerIsActive;

    private float targetTime = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorCollider.SetActive(false);
        timerIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver() {
        if(targetTime > 0f) {
            targetTime -= Time.deltaTime;
            if(targetTime <= 0f) {
                Invoke(nameof(StartEvent), 0.1f);
            } 
        }
        
    }

    private void StartEvent() {
        SoundManager.PlaySound(SoundManager.Sound.DoorSlam);
        SoundManager.PlaySound(SoundManager.Sound.ScaryShock);
        doorCollider.SetActive(true);
        Destroy(this.gameObject);
    }

}
