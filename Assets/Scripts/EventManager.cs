using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    [Tooltip("Variable that defines the tag that the trigger2D Collides with")]
    public string tagToActivate = "Player";

    public UnityEvent onTriggerEnter, onTriggerExit;

    private void Awake()
    {
        if (GetComponent<Collider2D>() == null)
        {
            Debug.Log($"{gameObject} is missing a Collider2D");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagToActivate))
        {
            onTriggerEnter.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(tagToActivate))
        {
            onTriggerExit.Invoke();
        }
    }
}