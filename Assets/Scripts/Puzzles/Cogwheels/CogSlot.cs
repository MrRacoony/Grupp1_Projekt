using System.Collections.Generic;
using UnityEngine;

public class CogSlot : MonoBehaviour
{

    private bool isOccupied;
    private List<GameObject> cogSlots;
    [SerializeField] private bool isCorrectSlot;

    void Start() {
        cogSlots = GameObject.Find("CogManager").GetComponent<CogManager>().GetCogSlots();
        isOccupied = false;
    }

    public void SetOccupied(bool input) {
        isOccupied = input;
    }

    public bool GetIsOccupied() {
        return isOccupied;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        for (int i = 0; i < cogSlots.Count; i++)
        {
            if (EndsWithSameLetter(this.name, collision.name))
            {
                isCorrectSlot = true;
                break;
            }
            else
            {
                isCorrectSlot = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isCorrectSlot = false;
    }
    public static bool EndsWithSameLetter(string a, string b)
    {
        if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
        {
            Debug.Log("One or both strings are null or empty.");
            return false;
        }

        char lastA = a[a.Length - 1];
        char lastB = b[b.Length - 1];

        return lastA == lastB;
    }

    public bool GetCorrectSlot()
    {
        return isCorrectSlot;
    }

}
