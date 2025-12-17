using NUnit.Framework;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class ChessManager : MonoBehaviour
{

    [SerializeField] private GameObject currentPiece;
    [SerializeField] private List<GameObject> correctTiles, allTiles;

    private bool hasPiece;
    private bool isCorrect;
    private Color baseColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasPiece = false;
        isCorrect = false;
        for (int i=0; i<GameObject.Find("ChessTiles").transform.childCount; i++) {
            allTiles.Add(GameObject.Find("ChessTiles").transform.GetChild(i).gameObject);
        }
    }

    public void SetCurrentPiece(GameObject piece) {
        if (piece != currentPiece)
        {
            currentPiece = piece;
            baseColor = currentPiece.GetComponent<SpriteRenderer>().color;
            currentPiece.GetComponent<SpriteRenderer>().color = Color.cyan;
            hasPiece = true;
        }
    }

    public bool GetHasPiece() {
        return hasPiece;
    }

    public bool GetIsCorrect() {
        return isCorrect;
    }

    public GameObject GetPiece() {
        return currentPiece;
    }

    public void ResetPiece() {
        currentPiece.GetComponent<SpriteRenderer>().color = baseColor;
        currentPiece = null;
        hasPiece = false;
    }

    public bool CheckCorrectTiles() {
        for(int i=0; i<correctTiles.Count; i++) {
            if(!correctTiles[i].GetComponent<ChessTile>().GetIsActivated()) {
                return false;
            }
        }
        
        return true;
    }

    public Color GetBaseColor()
    {
        return baseColor;
    }

    public void SetCorrect(bool input) {
        isCorrect = input;
    }

    public void ComparePieces() {
        for(int i=0; i<allTiles.Count; i++) {
            if(GameObject.ReferenceEquals(allTiles[i].GetComponent<ChessTile>().GetTilePiece(), currentPiece)) {
                allTiles[i].GetComponent<ChessTile>().ResetTile();
            }
        }
    }

}
