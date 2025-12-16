using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static string currentScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        if (currentScene == null)
        {
            currentScene = SceneManager.GetActiveScene().name;
        }
    }

    public static void OpenSceneAddition(string newScene) {
        if (currentScene == null)
        {
            currentScene = SceneManager.GetActiveScene().name;
        }
        
        //MonsterScript monsterScript = GameObject.FindAnyObjectByType<MonsterScript>();
        Scene scene = SceneManager.GetSceneByName(newScene);
        
        //monsterScript.MonsterScene(newScene);
        if (scene.isLoaded)
        {
            foreach (GameObject root in scene.GetRootGameObjects())
            {
                root.SetActive(true);

                /*foreach (Transform child in root.GetComponentsInChildren<Transform>(true))
                {
                    if (child.tag == "TutorialObject" && !monsterScript.taggedObjects.Contains(child.gameObject))
                    {
                        monsterScript.taggedObjects.Add(child.gameObject);
                    }
                }*/

            }
            //foreach (GameObject root in scene.GetRootGameObjects())
            //{

            //    root.SetActive(true);
            //    if (root.CompareTag("TutorialObject") && !monsterScript.taggedObjects.Contains(root))
            //    {
            //        monsterScript.taggedObjects.Add(root);
            //    }
            //}
        }
        else
        {
            SceneManager.sceneLoaded += (loadedScene, mode) =>
            {
                foreach (GameObject root in loadedScene.GetRootGameObjects())
                {
                    /*foreach (Transform child in root.GetComponentsInChildren<Transform>(true))
                    {

                        if (child.tag == "TutorialObject" && !monsterScript.taggedObjects.Contains(child.gameObject))
                        {
                            monsterScript.taggedObjects.Add(child.gameObject);
                        }
                    }*/
                }
            };

            
            SceneManager.LoadScene(newScene, LoadSceneMode.Additive);

        }
        Debug.Log(currentScene);
        CloseSceneTemporary(currentScene);
        currentScene = newScene;
        Debug.Log("Current Scene: " + currentScene);
    }

    public static void CloseSceneTemporary(string OldScene)
    {
        SoundManager.PlaySound(SoundManager.Sound.UIClick);
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

    public string GetScene()
    {
        return currentScene;
        //return currentScene;
    }
    public void SetScene(string newScene)
    {
        currentScene = newScene;
    }
}
