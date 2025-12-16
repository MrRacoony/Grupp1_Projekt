using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool gamePaused = false;
    private Canvas pauseCanvas;

    [SerializeField] private GameObject pauseMenuUI;
    private DialogueUI dialogue;

    [SerializeField] private List<Collider2D> interactables;
    private List<Canvas> canvases = new List<Canvas>();
    // Update is called once per frame
    private void Start()
    {
        pauseCanvas = pauseMenuUI.GetComponentInParent<Canvas>();
        Pause();
        Resume();
    }
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
        dialogue = FindAnyObjectByType<DialogueUI>();
        if (!dialogue.IsInDialogue())
        {
            foreach (Collider2D interact in interactables)
            {
                interact.enabled = true;
            }
            foreach (Canvas c in canvases)
            {
                if (c != pauseCanvas)
                {
                    c.enabled = true;
                }
            }
        }
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void Pause()
    {
        dialogue = FindAnyObjectByType<DialogueUI>();
        if (!dialogue.IsInDialogue())
        {
            interactables.Clear();
            canvases.Clear();
            interactables.AddRange(FindObjectsByType<Collider2D>(FindObjectsSortMode.None));
            canvases.AddRange(FindObjectsByType<Canvas>(FindObjectsInactive.Include, FindObjectsSortMode.None));
            foreach (Canvas c in canvases)
            {
                if (c != pauseCanvas)
                {
                    c.enabled = false;
                }
            }
            foreach (Collider2D interact in interactables)
            {
                interact.enabled = false;
            }
        }
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        
    }
    public void Menu()
    {
        SceneController.LoadScene("Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
