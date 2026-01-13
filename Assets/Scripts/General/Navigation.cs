using UnityEngine;

public class Navigation : MonoBehaviour
{

    [SerializeField] private string nextScene;
    [SerializeField] private Texture2D arrowCursor;
    [SerializeField] private Vector2 circleCursor = new Vector2(72, 72);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnMouseEnter() {
    Cursor.SetCursor(arrowCursor, new Vector2(arrowCursor.width/2, arrowCursor.height/2), CursorMode.Auto);
    }

    private void OnMouseDown() {
        if(nextScene == "Bedroom") {
            SoundManager.SetVolume(SoundManager.Sound.RadioStation1, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation2, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation3, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation4, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioStation5, 0f);
            SoundManager.SetVolume(SoundManager.Sound.RadioDialStatic, 0f);
            
            SoundManager.SetVolume(SoundManager.Sound.Ambience1, 1.0f);
            SoundManager.SetVolume(SoundManager.Sound.Ambience2, 0f);
        }
        else if(nextScene == "IntersectionRoom") {
            SoundManager.SetVolume(SoundManager.Sound.Ambience2, 1.0f);
            SoundManager.SetVolume(SoundManager.Sound.Ambience1, 0f);
            SoundManager.SetVolume(SoundManager.Sound.Ambience3, 0f);
        }
        else if(nextScene == "Lounge") {
            SoundManager.SetVolume(SoundManager.Sound.Ambience3, 1.0f);
            SoundManager.SetVolume(SoundManager.Sound.Ambience2, 0f);
        }
        SoundManager.PlaySound(SoundManager.Sound.UIClick);
        SceneController.OpenSceneAddition(nextScene);
        Cursor.SetCursor(null, circleCursor, CursorMode.Auto);
    }

    private void OnMouseExit() {
        Cursor.SetCursor(null, circleCursor, CursorMode.Auto);
    }

}