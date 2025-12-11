using NUnit.Framework;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class CogManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> cogSlots;

    private GameObject currentCog;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> GetCogSlots() {
        return cogSlots;
    }

}
