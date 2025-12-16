using UnityEngine;

public class Navigation : MonoBehaviour
{

    [SerializeField] private string nextScene;
    [SerializeField] private GameObject arrowCursor;
    
    private GameObject circleCursor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        circleCursor = GameObject.Find("CircleCursor");
    }

    private void OnMouseOver() {
        circleCursor.SetActive(false);
        Vector3 mousePos = Input.mousePosition;
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
        circleCursor.SetActive(true);
    }

    private void OnMouseExit() {
        arrowCursor.SetActive(false);
        circleCursor.SetActive(true);
    }

}