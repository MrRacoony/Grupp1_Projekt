using NUnit.Framework;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class Padlock : MonoBehaviour
{

    [SerializeField] private List<GameObject> padlocks;

    private bool isUnlocked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isUnlocked = false;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            padlocks.Add(this.transform.GetChild(i).gameObject);
        }
    }
    
    public void TryUnlock() {
        if(padlocks[0].GetComponent<PadlockNumber>().GetIsCorrect() && padlocks[1].GetComponent<PadlockNumber>().GetIsCorrect()
        && padlocks[2].GetComponent<PadlockNumber>().GetIsCorrect() && isUnlocked == false) {
            isUnlocked = true;
            SoundManager.PlaySound(SoundManager.Sound.PadlockUnlocked); 
            Debug.Log("Unlocked");
        }
    }
}
