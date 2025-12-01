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
        render = GetComponent<SpriteRenderer>();
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
        render.color = new Color(0, 255, 255);
    }
    private void OnMouseDown()
    {
        MinigameController.OpenMinigame(sceneName);
        render.color = new Color(255, 255, 255);
    }
    private void OnMouseExit()
    {
        render.color = new Color(255, 255, 255);
    }
}
