using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorObject : MonoBehaviour
{

    [SerializeField] private GameObject inventory;
    [SerializeField] private string nextScene;

    [SerializeField] private string currentScene;

    private bool isOpen;

    private Animator anim;

    // Update is called once per frame
    void Start()
    {
        ;
        anim = GetComponent<Animator>();
        isOpen = false;
    }

    private void OnMouseDown()
    {
        inventory = GameObject.Find("Inventory");
        if(inventory != null) {
            if(inventory.GetComponent<InventorySystem>().HasObject("BedroomKey") && !isOpen) {
                SoundManager.PlaySound(SoundManager.Sound.DoorOpening);
                isOpen = true;  
                anim.SetBool("isOpen", isOpen);
            }
        }
        else if(isOpen) {
            //scene change here
            SceneController.LoadScene(nextScene);
            //SceneController.CloseSceneTemporary(currentScene);
        }
        else {
            SoundManager.PlaySound(SoundManager.Sound.DoorLocked);
        }
        
    }

    private void OnBecameVisible() {
        if(anim.GetBool("isOpen") != isOpen) {
            anim.SetBool("isOpen", isOpen);
        }
    }

}
