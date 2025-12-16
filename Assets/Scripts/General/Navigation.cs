using UnityEngine;

public class Navigation : MonoBehaviour
{

    [SerializeField] private string nextScene;
    [SerializeField] private GameObject arrowCursor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
                
    }

    private void OnMouseOver() {
        Vector3 mousePos = Input.mousePosition;
        Cursor.visible = false;
        arrowCursor.SetActive(true);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
        arrowCursor.transform.position = new Vector2(worldPos.x, worldPos.y);
    }

    private void OnMouseDown() {
        SoundManager.PlaySound(SoundManager.Sound.UIClick);
        SceneController.OpenSceneAddition(nextScene);
        arrowCursor.SetActive(false);
        Cursor.visible = true;
    }

    private void OnMouseExit() {
        arrowCursor.SetActive(false);
        Cursor.visible = true;
    }

}