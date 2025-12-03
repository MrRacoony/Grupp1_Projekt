using NUnit.Framework;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class PaperObjects : MonoBehaviour
{

    [SerializeField] private List<GameObject> papers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            papers.Add(this.transform.GetChild(i).gameObject);
        }
    }

    public List<GameObject> GetList() {
        return papers;
    }
    
}
