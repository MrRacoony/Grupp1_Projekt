using UnityEngine;
using UnityEngine.SceneManagement;

public static class MinigameController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static void OpenMinigame(string minigame)
    {
        var mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        var miniCam = GameObject.Find("Minigame Camera").GetComponent<Camera>();

        mainCam.enabled = false;
        miniCam.enabled = true;

        CameraService.SetActiveCamera(miniCam);

        SceneManager.LoadScene(minigame, LoadSceneMode.Additive);
    }

    public static void CloseMinigame(string minigame)
    {
        SceneManager.UnloadSceneAsync(minigame);

        var mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        var miniCam = GameObject.Find("Minigame Camera").GetComponent<Camera>();

        mainCam.enabled = true;
        miniCam.enabled = false;

        CameraService.SetActiveCamera(mainCam);
    }

}
