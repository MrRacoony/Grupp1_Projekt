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
        SoundManager.PlaySound(SoundManager.Sound.DoorSlam);
        SoundManager.PlaySound(SoundManager.Sound.ScaryShock);
        doorCollider.SetActive(true);
        Destroy(this.gameObject);
    }

}
