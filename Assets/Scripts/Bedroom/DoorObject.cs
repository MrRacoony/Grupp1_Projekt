using UnityEngine;

public class DoorObject : MonoBehaviour
{

    [SerializeField] private GameObject inventory;

    private bool isOpen;

    private Animator anim;

    // Update is called once per frame
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = false;
    }

    void Update() {
        if(anim.GetBool("isOpen") != isOpen) {
            anim.SetBool("isOpen", isOpen);
        }
    }

    private void OnMouseDown()
    {
        inventory = GameObject.Find("Inventory");
        if(inventory.GetComponent<InventorySystem>().HasObject("BedroomKey") && !isOpen) {
            SoundManager.PlaySound(SoundManager.Sound.DoorOpening);
            isOpen = true;
            anim.SetBool("isOpen", isOpen);
        }
        else if(isOpen) {
            //scene change here
        }
        else {
            SoundManager.PlaySound(SoundManager.Sound.PadlockUnlocked);
        }
    }

}
