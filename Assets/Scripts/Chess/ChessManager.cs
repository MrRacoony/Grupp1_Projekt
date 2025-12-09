using UnityEngine;

public class ChessManager : MonoBehaviour
{

    [SerializeField] private GameObject currentPiece;

    private bool hasPiece;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasPiece = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentPiece(GameObject piece) {
        currentPiece = piece;
        hasPiece = true;
    }

    public bool GetHasPiece() {
        return hasPiece;
    }

    public GameObject GetPiece() {
        return currentPiece;
    }

    public void ResetPiece() {
        currentPiece = null;
        hasPiece = false;
    }

}
