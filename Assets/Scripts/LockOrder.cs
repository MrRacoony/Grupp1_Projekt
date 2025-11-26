using NUnit.Framework;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class LockOrder : MonoBehaviour
{
    [SerializeField] private List<GameObject> unusedLocks;
    [SerializeField] private List<GameObject> lockOrder;
    System.Random rnd = new System.Random();
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
