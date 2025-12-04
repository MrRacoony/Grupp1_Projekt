using UnityEngine;

public class DoorObject : MonoBehaviour
{

    [SerializeField] private GameObject inventory;

    private bool isOpen;

    // Update is called once per frame
    void Start()
    {
        isOpen = false;
    }

    private void OnMouseDown() {
        if(inventory.GetComponent<InventorySystem>().HasObject("BedroomKey") && !isOpen) {
            SoundManager.PlaySound(SoundManager.Sound.DoorOpening);
            isOpen = true;
        }
        else {
            SoundManager.PlaySound(SoundManager.Sound.PadlockInteract);
        }
    }

}
