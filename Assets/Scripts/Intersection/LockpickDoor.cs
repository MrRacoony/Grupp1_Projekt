using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using Unity.Mathematics;

public class LockpickDoor : MonoBehaviour
{

    [SerializeField] private GameObject inventory;
    [SerializeField] private string nextScene;
    [SerializeField] private Texture2D arrowCursor;
    [SerializeField] private Vector2 circleCursor = new Vector2(72, 72);

    [SerializeField] private List<GameObject> layersToOpen;
    [SerializeField] private List<GameObject> layersToClose;

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
            Debug.Log("Door is unlocked.");
            Cursor.SetCursor(arrowCursor, new Vector2(arrowCursor.width, arrowCursor.height), CursorMode.Auto);
        }
    }

    private void OnMouseDown()
    {
        inventory = GameObject.Find("Inventory");
        
        if(inventory != null && !isUnlocked) {
            SoundManager.PlaySound(SoundManager.Sound.UIClick);
            if (inventory.GetComponent<InventorySystem>().HasObject("Paperclip")) {
                for(int i=0; i<layersToOpen.Count; i++) {
                    layersToOpen[i].SetActive(true);
                }
                for(int i=0; i<layersToClose.Count; i++) {
                    layersToClose[i].SetActive(false);
                }
            }
            else {
                SoundManager.PlaySound(SoundManager.Sound.DoorLocked);
            }
        }
        else if(!isUnlocked) {
            SoundManager.PlaySound(SoundManager.Sound.DoorLocked);
        }        
        
        if(isUnlocked) {
            SceneManager.LoadScene(nextScene);
        }
        
    }

    private void OnMouseExit() {
            Cursor.SetCursor(null, circleCursor, CursorMode.Auto);
    }

    public void SetUnlocked() {
        isUnlocked = true;
        Debug.Log("Door is now unlocked.");
    }

    public void CloseLayer() {
        SoundManager.PlaySound(SoundManager.Sound.UIClick);
        for(int i=0; i<layersToOpen.Count; i++) {
            layersToOpen[i].SetActive(false);
        }
        for(int i=0; i<layersToClose.Count; i++) {
            layersToClose[i].SetActive(true);
        }
    }

}
