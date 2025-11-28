using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets _instance;
    public static GameAssets instance
    {
        get 
        {
            if (_instance == null)
            {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/GameAssets");
                _instance = Instantiate(prefab).GetComponent<GameAssets>();
            }
            return _instance;
        }
    }

    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
        public bool looping;
    }
}
