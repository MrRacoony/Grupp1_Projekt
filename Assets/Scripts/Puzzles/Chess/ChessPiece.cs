using UnityEngine;

public class ChessPiece : MonoBehaviour
{

    private void OnMouseOver() {
        
    }

    void OnMouseDown() {
        
        if(!transform.parent.GetComponent<ChessManager>().GetIsCorrect()) {
            transform.parent.GetComponent<ChessManager>().SetCurrentPiece(this.gameObject);
        }
        
    }

    private void Update() {

    }

}
