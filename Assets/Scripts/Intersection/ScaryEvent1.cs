using UnityEngine;

public class ScaryEvent1 : MonoBehaviour
{

    [SerializeField] private GameObject doorCollider;

    private bool hasHappened;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver() {
        Invoke(nameof(StartEvent), 0.1f);
    }

    private void StartEvent() {
        SoundManager.PlaySound(SoundManager.Sound.DoorSlam);
        SoundManager.PlaySound(SoundManager.Sound.ScaryShock);
        doorCollider.SetActive(true);
        Destroy(this.gameObject);
    }

}
