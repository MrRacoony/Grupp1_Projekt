using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{

    public bool isUnlocked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUnlocked(bool input) {
        isUnlocked = input;
    }

}
