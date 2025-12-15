using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SpriteRenderer render;
    private GameObject parentObject;
    [SerializeField] private string nextScene;

    private void OnMouseOver()
    {
        transform.localScale = Vector3.one * 1.1f;
    }
    private void OnMouseDown()
    {
        SoundManager.PlaySound(SoundManager.Sound.UIClick);
        SceneController.OpenSceneAddition(nextScene);
        transform.localScale = Vector3.one;
    }
    private void OnMouseExit()
    {
        transform.localScale = Vector3.one;
    }
}
