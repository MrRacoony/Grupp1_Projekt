using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PianoManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private List<GameObject> pianoKeys = new List<GameObject>();
    [SerializeField] private List<GameObject> correctSequence = new List<GameObject>();
    [SerializeField] private List<GameObject> playerSequence = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < GameObject.FindObjectsByType<PianoKey>(FindObjectsSortMode.None).Length; i++)
        {
            pianoKeys.Add(GameObject.FindObjectsByType<PianoKey>(FindObjectsSortMode.None)[i].gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < pianoKeys.Count; i++)
        {
            if (pianoKeys[i].GetComponent<PianoKey>().IsPlaying() && playerSequence.Count < correctSequence.Count)
            {
                pianoKeys[i].GetComponent<PianoKey>().SetPlaying(false);
                if (pianoKeys[i] == correctSequence[playerSequence.Count])
                {
                    playerSequence.Add(pianoKeys[i]);
                    if (correctSequence.Count == playerSequence.Count)
                    {
                        Debug.Log("Puzzle Solved!");
                    }
                }
                else
                {
                    Debug.Log("Wrong Key! Try Again.");
                    playerSequence.Clear();
                }
            }
        }

    }
}
