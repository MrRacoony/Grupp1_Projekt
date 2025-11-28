using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadScript : MonoBehaviour
{
    public void Start()
    {
        
    }
    public void Awake()
    {
        SoundManager.PlaySound(SoundManager.Sound.MenuTheme);
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
