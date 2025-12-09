using UnityEngine;

public class ChessPiece : MonoBehaviour
{

    void OnMouseDown() {
        
        transform.parent.GetComponent<ChessManager>().SetCurrentPiece(this.gameObject);
        
    }

    private void Update() {

    }

}
