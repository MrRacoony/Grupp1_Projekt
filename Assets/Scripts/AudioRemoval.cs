using UnityEngine;

public class AudioRemoval : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioSource m_AudioSource;
    void Start()
    {
        m_AudioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_AudioSource.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
}
