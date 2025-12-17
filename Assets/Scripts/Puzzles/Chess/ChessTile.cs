using UnityEngine;

public class ChessTile : MonoBehaviour
{

    [SerializeField] private bool isActivated;

    private GameObject tilePiece;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isActivated = false;
    }

    void OnMouseDown() {
        
        if(transform.parent.transform.parent.GetComponent<ChessManager>().GetHasPiece()) {
            SoundManager.PlaySound(SoundManager.Sound.ChesspiecePlace);
            transform.parent.transform.parent.GetComponent<ChessManager>().ComparePieces();
            isActivated = true;
            tilePiece = transform.parent.transform.parent.GetComponent<ChessManager>().GetPiece();
            transform.parent.transform.parent.GetComponent<ChessManager>().GetPiece().transform.position = new Vector3(transform.position.x, transform.position.y, -1.0f);
            transform.parent.transform.parent.GetComponent<ChessManager>().ResetPiece();
            transform.parent.transform.parent.GetComponent<ChessManager>().SetCorrect(transform.parent.transform.parent.GetComponent<ChessManager>().CheckCorrectTiles());
        }
    }

    public bool GetIsActivated() {
        return isActivated;
    }

    public void SetActivated(bool input) {
        isActivated = input;
    }

    public GameObject GetTilePiece() {
        return tilePiece;
    }

    public void ResetTile() {
        isActivated = false;
        tilePiece = null;
    }

}