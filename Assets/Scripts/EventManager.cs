using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    [Tooltip("The colliding object that we want to trigger these events with needs to use a tag of the same name as typed in this variable")]
=======
    [Tooltip("Variable that defines the tag that the trigger2D Collides with")]
>>>>>>> Stashed changes
=======
    [Tooltip("Variable that defines the tag that the trigger2D Collides with")]
>>>>>>> Stashed changes
    public string tagToActivate = "Player";

    public UnityEvent onTriggerEnter, onTriggerExit;

    private void Awake()
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        if ((GetComponent<Collider>() == null) && (GetComponent<Collider2D>() == null))
        {
            Debug.Log($"{gameObject} is missing a collider");
=======
        if (GetComponent<Collider2D>() == null)
        {
            Debug.Log($"{gameObject} is missing a Collider2D");
>>>>>>> Stashed changes
=======
        if (GetComponent<Collider2D>() == null)
        {
            Debug.Log($"{gameObject} is missing a Collider2D");
>>>>>>> Stashed changes
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagToActivate))
        {
            onTriggerEnter.Invoke();
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            Debug.Log("Unity Event Trigger (enter) activated on " + gameObject);
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(tagToActivate))
        {
            onTriggerExit.Invoke();
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            Debug.Log("Unity Event Trigger (exit) activated on " + gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToActivate))
        {
            onTriggerEnter.Invoke();
            Debug.Log("Unity Event Trigger (enter) activated on " + gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagToActivate))
        {
            onTriggerExit.Invoke();
            Debug.Log("Unity Event Trigger (exit) activated on " + gameObject);
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        }
    }
}