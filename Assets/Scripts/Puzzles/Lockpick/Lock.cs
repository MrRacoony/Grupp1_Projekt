using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{

    [SerializeField] private Animator anim;

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
        anim.SetBool("isUnlocked", input);
    }

    public bool GetUnlocked() {
        return isUnlocked;
    }

}
