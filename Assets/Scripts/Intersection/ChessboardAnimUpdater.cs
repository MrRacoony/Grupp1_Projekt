using UnityEngine;

public class ChessboardAnimUpdater : MonoBehaviour
{

    [SerializeField] private GameObject chessboard;
    [SerializeField] private Animator chessAnimator;

    private void OnMouseDown() {
        UpdateAnimState();
    }

    public void UpdateAnimState() {
        chessAnimator.SetBool("isOpen", chessboard.GetComponent<ChessManager>().GetIsCorrect());
    }

}