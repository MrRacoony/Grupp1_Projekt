using UnityEngine;
using UnityEngine.SceneManagement;

public static class MinigameController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static void OpenMinigame(string minigame)
    {
        Scene scene = SceneManager.GetSceneByName(minigame);

        var mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        var miniCam = GameObject.Find("Minigame Camera").GetComponent<Camera>();

        mainCam.enabled = false;
        miniCam.enabled = true;

        CameraService.SetActiveCamera(miniCam);
        if (scene.isLoaded)
        {
            foreach (GameObject root in scene.GetRootGameObjects())
            {
                root.SetActive(true);
            }

        }
        else
        {
            SceneManager.LoadScene(minigame, LoadSceneMode.Additive);
        }
        
    }

    public static void CloseMinigame(string minigame)
    {
        Scene scene = SceneManager.GetSceneByName(minigame);
        foreach (GameObject root in scene.GetRootGameObjects())
        {
            root.SetActive(false); // hide everything
        }

        var mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        var miniCam = GameObject.Find("Minigame Camera").GetComponent<Camera>();

        mainCam.enabled = true;
        miniCam.enabled = false;

        CameraService.SetActiveCamera(mainCam);
    }


}
