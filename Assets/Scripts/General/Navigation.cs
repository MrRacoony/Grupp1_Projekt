using UnityEngine;

public class Navigation : MonoBehaviour
{

    [SerializeField] private string nextScene;
    [SerializeField] private Texture2D arrowCursor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnMouseEnter() {
    Cursor.SetCursor(arrowCursor, Vector2.zero, CursorMode.Auto);
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
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

}