using NUnit.Framework;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class Padlock : MonoBehaviour
{

    private List<GameObject> padlocks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            padlocks.Add(this.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(padlocks[0].GetComponent<PadlockNumber>().GetIsCorrect() && padlocks[1].GetComponent<PadlockNumber>().GetIsCorrect()
        && padlocks[2].GetComponent<PadlockNumber>().GetIsCorrect()) {
            Unlock();
        }
    }
    
    private void Unlock() {
        Debug.Log("Unlocked");
    }
}
