using NUnit.Framework;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class ChestAnimController : MonoBehaviour
{

    [SerializeField] private GameObject padlock;
    [SerializeField] private Animator chestAnimator;

    private void OnMouseDown() {
        UpdateAnimState();
    }

    public void UpdateAnimState() {
        chestAnimator.SetBool("isOpen", padlock.GetComponent<Padlock>().GetIsUnlocked());
    }

}
