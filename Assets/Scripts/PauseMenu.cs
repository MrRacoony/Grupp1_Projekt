using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool gamePaused = false;

    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private List<Collider2D> interactables;
    private GameObject gamePlayCanvas;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        foreach (Collider2D interact in interactables)
        {
            interact.enabled = true;
        }
        if (gamePlayCanvas != null)
        {
            gamePlayCanvas.SetActive(true);
        }
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void Pause()
    {
        interactables.Clear();
        Scene scene = SceneManager.GetSceneByName(SceneController.currentScene);
        Debug.Log(SceneController.currentScene);
        interactables.AddRange(FindObjectsByType<Collider2D>(FindObjectsSortMode.None));
        if (GameObject.Find("GamePlayCanvas") != null)
        {
            gamePlayCanvas = GameObject.Find("GamePlayCanvas");
            gamePlayCanvas.SetActive(false);
        }
        foreach (Collider2D interact in interactables)
        {
            interact.enabled = false;
        }
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        
    }
}
