using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LockpickDoor : MonoBehaviour
{

    [SerializeField] private GameObject inventory;
    [SerializeField] private string nextScene;
    [SerializeField] private Texture2D arrowCursor;
    [SerializeField] private Vector2 circleCursor = new Vector2(72, 72);

    [SerializeField] ChessManager chess;
    
    private bool isUnlocked;

    // Update is called once per frame
    void Start()
    {
        GetComponent<Collider2D>().enabled = false;
        isUnlocked = false;
    }
    private void Update()
    {
        
        if (chess != null)
        {
            GetComponent<Collider2D>().enabled = chess.CheckCorrectTiles();
        }
        else
        {
            chess = FindAnyObjectByType<ChessManager>();
        }
    }

    private void OnMouseEnter()
    {
        if(isUnlocked) {
            Cursor.SetCursor(arrowCursor, new Vector2(arrowCursor.width, arrowCursor.height), CursorMode.Auto);
        }
    }

    private void OnMouseDown()
    {
        inventory = GameObject.Find("Inventory");
        if (inventory != null && !isUnlocked) {
            if (inventory.GetComponent<InventorySystem>().HasObject("Paperclip")) {
                SceneController.OpenSceneAddition("Lockpicking");
            }
            else {
                SoundManager.PlaySound(SoundManager.Sound.DoorLocked);
            }
        }
        else if(inventory != null && isUnlocked) {
            SceneController.OpenSceneAddition(nextScene);
        }
        else {
            SoundManager.PlaySound(SoundManager.Sound.DoorLocked);
        }
    }

    private void OnMouseExit() {
            Cursor.SetCursor(null, circleCursor, CursorMode.Auto);
    }

    public void SetUnlocked() {
        isUnlocked = true;
    }

}
