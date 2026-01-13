using UnityEngine;

public class FadeIn : MonoBehaviour
{

    private SpriteRenderer sprend;

    private float targetTime = 3f;
    private float alpha = 1f;

    private bool isOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprend = GetComponent<SpriteRenderer>();
        sprend.color = new Color(0f,0f,0f, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if(targetTime > 0f) {
            targetTime -= Time.deltaTime;
            if(targetTime <= 0f) {
                isOn = true;
            }
        }

        if(alpha > 0f && isOn) {
            alpha -= 0.001f;
            sprend.color = new Color(0f,0f,0f, alpha);
        }
        
    }
}
