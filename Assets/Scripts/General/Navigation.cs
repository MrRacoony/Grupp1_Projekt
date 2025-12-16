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
        if(nextScene == "Bedroom") {
            SoundManager.SetVolume(SoundManager.Sound.Ambience1, 1.0f);
            SoundManager.SetVolume(SoundManager.Sound.Ambience2, 0f);
        }
        else if(nextScene == "IntersectionRoom") {
            SoundManager.SetVolume(SoundManager.Sound.Ambience2, 1.0f);
            SoundManager.SetVolume(SoundManager.Sound.Ambience1, 0f);
        }
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