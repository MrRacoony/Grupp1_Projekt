using NUnit.Framework;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class LockOrder : MonoBehaviour
{
    [SerializeField] private List<GameObject> unusedLocks;
    [SerializeField] public List<GameObject> lockOrder;
    System.Random rnd = new System.Random();

    private float lockedYPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            unusedLocks.Add(this.transform.GetChild(i).gameObject);
        }
        
        for (int i = 0; i < unusedLocks.Count; i++)
        {
            int index = rnd.Next(0, unusedLocks.Count);
            if (lockOrder.Contains(unusedLocks[index]))
            {
                i--;
                continue;
            }
            lockOrder.Add(unusedLocks[index]);
        }
        
        lockedYPos = lockOrder[0].transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLocked() {
        for(int i=0; i<lockOrder.Count; i++) {
            lockOrder[i].transform.position = new Vector2(lockOrder[i].transform.position.x, lockedYPos);
            lockOrder[i].GetComponent<Lock>().SetUnlocked(false);
        }
    }

    public int GetLockAmount() {
        return lockOrder.Count;
    }

}
