using NUnit.Framework;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{

    [SerializeField] private List<string> heldObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void AddObject(string objectName) {
        heldObjects.Add(objectName);
    }

    public bool HasObject(string objectName) {
        for(int i=0; i<heldObjects.Count; i++) {
            if(heldObjects[i] == objectName) {
                return true;
            }
        }
        return false;
    }

}
