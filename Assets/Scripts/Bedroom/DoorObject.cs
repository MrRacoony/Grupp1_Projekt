using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorObject : MonoBehaviour
{

    [SerializeField] private GameObject inventory;
    [SerializeField] private string nextScene;
    [SerializeField] private GameObject arrowCursor;

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

    private void OnMouseOver() {
        if(isOpen) {
            Vector3 mousePos = Input.mousePosition;
            Cursor.visible = false;
            arrowCursor.SetActive(true);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
            arrowCursor.transform.position = new Vector2(worldPos.x, worldPos.y);
        }
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
            else if(isOpen) {
                //scene change here
                SoundManager.SetVolume(SoundManager.Sound.Ambience2, 1.0f);
                SoundManager.SetVolume(SoundManager.Sound.Ambience1, 0f);
                SceneController.OpenSceneAddition(nextScene);
                arrowCursor.SetActive(false);
                Cursor.visible = true;
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
            arrowCursor.SetActive(false);
            Cursor.visible = true;
        }
    }

    private void OnBecameVisible() {
        if(anim.GetBool("isOpen") != isOpen) {
            anim.SetBool("isOpen", isOpen);
        }
    }

}
