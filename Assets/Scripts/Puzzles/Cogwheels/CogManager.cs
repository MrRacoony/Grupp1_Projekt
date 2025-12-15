using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CogManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> cogSlots;
    [SerializeField] private List<CogPlaceable> cogWheels;

    private GameObject currentCog;
    [SerializeField] private bool completed;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cogWheels.Clear();
        cogWheels.AddRange(GameObject.FindObjectsByType<CogPlaceable>(FindObjectsSortMode.None));
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cogSlots.Count; i++)
        {
            if (!cogSlots[i].GetComponent<CogSlot>().GetCorrectSlot())
            {
                Reset();
                return;
            }
        }
        Victory();
        Debug.Log("Puzzle Solved!");
    }

    public List<GameObject> GetCogSlots() {
        return cogSlots;
    }

    public void Reset()
    {
        completed = false;
        for (int i = 0; i < cogWheels.Count; i++)
        {
            cogWheels[i].transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Victory()
    {
        completed = true;
        for (int i = 0; i < cogWheels.Count; i++)
        {
            Debug.Log("Rotating Cogs");
            cogWheels[i].transform.rotation = Quaternion.Euler(0, 0, cogWheels[i].transform.rotation.eulerAngles.z + (Time.deltaTime * 45));
        }
    }

}
