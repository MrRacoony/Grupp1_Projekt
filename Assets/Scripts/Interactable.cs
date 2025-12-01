using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Interactable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SpriteRenderer render;
    private GameObject parentObject;
    public string sceneName;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject minigameCamera = GameObject.Find("Minigame Camera");
        if (minigameCamera != null && minigameCamera.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MinigameController.CloseMinigame(sceneName);
            }

        }

    }

    private void OnMouseOver()
    {
        transform.localScale = Vector3.one * 1.1f;
    }
    private void OnMouseDown()
    {
        MinigameController.OpenMinigame(sceneName);
        transform.localScale = Vector3.one;
    }
    private void OnMouseExit()
    {
        transform.localScale = Vector3.one;
    }
}
