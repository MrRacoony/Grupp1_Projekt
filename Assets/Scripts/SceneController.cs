using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public static void OpenSceneAddition(string newScene)
    {
        MonsterScript monsterScript = GameObject.FindAnyObjectByType<MonsterScript>();
        Scene scene = SceneManager.GetSceneByName(newScene);
        if (scene.isLoaded)
        {

            foreach (GameObject root in scene.GetRootGameObjects())
            {

                root.SetActive(true);
                if (root.CompareTag("TutorialObject") && !monsterScript.taggedObjects.Contains(root))
                {
                    monsterScript.taggedObjects.Add(root);
                }
            }
        }
        else
        {
            SceneManager.sceneLoaded += (loadedScene, mode) =>
            {
                if (loadedScene.name == newScene)
                {
                    foreach (GameObject root in loadedScene.GetRootGameObjects())
                    {
                        Transform leaveTransform = root.transform.FindDeepChild("Leave");
                        if (leaveTransform != null)
                        {
                            GameObject leaveButton = leaveTransform.gameObject;
                            monsterScript.SetLeaveButton(leaveButton);
                        }


                        if (root.CompareTag("TutorialObject") && !monsterScript.taggedObjects.Contains(root))
                        {
                            monsterScript.taggedObjects.Add(root);
                        }
                    }
                }
            };

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
