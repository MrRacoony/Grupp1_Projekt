using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets _instance;
    public static GameAssets instance
    {
        get 
        {
            if (_instance == null) _instance = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _instance;
        }
    }

    public SoundAudioClip[] soundsArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public AudioManager.Sound sound;
        public AudioClip audioClip;
        public bool looping;
    }
}
