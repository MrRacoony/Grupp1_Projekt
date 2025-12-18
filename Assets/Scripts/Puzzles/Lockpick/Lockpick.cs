using NUnit.Framework;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class Lockpick : MonoBehaviour
{

    [SerializeField] private Transform verticalCast;
    [SerializeField] private LayerMask whatAreLocks;
    [SerializeField] private GameObject lockpickDoor;

    private Rigidbody2D rgbd;
    private float mouseXPos;
    public float minX;
    public float maxX;
    private float verticalRay = 1f;
    
    private int currentLock = 0;
    private int lockAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        if(lockpickDoor == null) {
            lockpickDoor = GameObject.Find("DoorRight");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mouseXPos =  Mathf.Clamp(mousePos.x, minX, maxX);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseXPos, mousePos.y, Camera.main.nearClipPlane));

        Vector2 origin = verticalCast.position;
        //Debug.DrawRay(origin, Vector2.up * verticalRay, Color.red);

        transform.position = new Vector2(worldPos.x, transform.position.y);

        if (Input.GetMouseButtonDown(0)) {
            CheckLock();
        }
        
    }

    private void CheckLock() {
        RaycastHit2D upHit = Physics2D.Raycast(verticalCast.position, Vector2.up, verticalRay, whatAreLocks);

        if(upHit.collider != null && upHit.collider.CompareTag("Lock")) {
            
            lockAmount = upHit.collider.transform.parent.GetComponent<LockOrder>().GetLockAmount();

            if(upHit.collider.GetComponent<Lock>().isUnlocked == false) {
                if(GameObject.ReferenceEquals(upHit.collider.transform.parent.GetComponent<LockOrder>().lockOrder[currentLock], upHit.collider.gameObject)) {
                    currentLock++;
                    upHit.collider.transform.position = new Vector2(upHit.collider.transform.position.x, upHit.collider.transform.position.y+1f   );
                    SoundManager.PlaySound(SoundManager.Sound.LockpickHit);
                    upHit.collider.GetComponent<Lock>().SetUnlocked(true);
                    Debug.Log("Has unlocked it");
                }
                else {
                    if(currentLock != 0) {
                        SoundManager.PlaySound(SoundManager.Sound.LockpickFail);
                    }
                    upHit.collider.transform.parent.GetComponent<LockOrder>().SetLocked();
                    currentLock = 0;
                    Debug.Log("Has locked all");
                }
            }

            if(upHit.collider.transform.parent.GetComponent<LockOrder>().lockOrder[lockAmount-1].GetComponent<Lock>().GetUnlocked()) {
                SoundManager.PlaySound(SoundManager.Sound.LockpickSuccess);
                SoundManager.PlaySound(SoundManager.Sound.DoorOpening);
                lockpickDoor.GetComponent<LockpickDoor>().SetUnlocked();
                lockpickDoor.GetComponent<LockpickDoor>().CloseLayer();
            }

        }
    }

}
