using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static void OpenSceneAddition(string newScene)
    {
        Scene scene = SceneManager.GetSceneByName(newScene);
        if (scene.isLoaded)
        {
            GameObject GOscene = GameObject.Find(newScene);
            GOscene.SetActive(true);
            //foreach (GameObject root in scene.GetRootGameObjects())
            //{
            //    root.SetActive(true);
            //}

        }
        else
        {
            SceneManager.LoadScene(newScene, LoadSceneMode.Additive);
        }
        
    }

    public static void CloseSceneTemporary(string OldScene)
    {
        GameObject scene = GameObject.Find(OldScene);
        scene.SetActive(false);
        //Scene scene = SceneManager.GetSceneByName(OldScene);
        //foreach (GameObject root in scene.GetRootGameObjects())
        //{
        //    root.SetActive(false); // hide everything
        //}

        //var mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        //var miniCam = GameObject.Find("Minigame Camera").GetComponent<Camera>();

        //mainCam.enabled = true;
        //miniCam.enabled = false;

        //CameraService.SetActiveCamera(mainCam);
    }
    public static void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


}
