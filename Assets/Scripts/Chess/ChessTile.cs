using UnityEngine;

public class ChessTile : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    void OnMouseDown() {
        
        if(transform.parent.transform.parent.GetComponent<ChessManager>().GetHasPiece()) {
            transform.parent.transform.parent.GetComponent<ChessManager>().GetPiece().transform.position = transform.position;
            transform.parent.transform.parent.GetComponent<ChessManager>().ResetPiece();
        }
        
    }

}
