using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorObject : MonoBehaviour
{

    [SerializeField] private GameObject inventory;
    [SerializeField] private string nextScene;
    [SerializeField] private Texture2D arrowCursor;
    [SerializeField] private Vector2 circleCursor = new Vector2(72, 72);

    [SerializeField] private string currentScene;

    private bool isOpen;

    private bool triggerDialogue = false;

    private Animator anim;

    // Update is called once per frame
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = false;
    }

    private void OnMouseEnter() {
        if(isOpen) {
            Cursor.SetCursor(arrowCursor, new Vector2(arrowCursor.width, arrowCursor.height), CursorMode.Auto);
        }
    }

    private void OnMouseDown()
    {
        inventory = GameObject.Find("Inventory");
        if(inventory != null) {
            if(inventory.GetComponent<InventorySystem>().HasObject("BedroomKey") && !isOpen) {
                Cursor.SetCursor(arrowCursor, new Vector2(arrowCursor.width, arrowCursor.height), CursorMode.Auto);
                SoundManager.PlaySound(SoundManager.Sound.DoorOpening);
                isOpen = true;  
                anim.SetBool("isOpen", isOpen);
            }
            else if(isOpen) {
                //scene change here
                SoundManager.SetVolume(SoundManager.Sound.Ambience2, 1.0f);
                SoundManager.SetVolume(SoundManager.Sound.Ambience1, 0f);
                SceneController.OpenSceneAddition(nextScene);
                Cursor.SetCursor(null, circleCursor, CursorMode.Auto);
                //SceneController.CloseSceneTemporary(currentScene);
            }
            else {
                SoundManager.PlaySound(SoundManager.Sound.DoorLocked);
                if (!triggerDialogue)
                {
                    triggerDialogue = true;
                    GetComponent<DialogueTrigger>().TriggerDialogue();
                }
            }
        }
        else {
            SoundManager.PlaySound(SoundManager.Sound.DoorLocked);
            if (!triggerDialogue)
            {
                triggerDialogue = true;
                GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }
    }

    private void OnMouseExit() {
        if(isOpen) {
            Cursor.SetCursor(null, circleCursor, CursorMode.Auto);
        }
    }

    private void OnBecameVisible() {
        if(anim.GetBool("isOpen") != isOpen) {
            anim.SetBool("isOpen", isOpen);
        }
    }

}
