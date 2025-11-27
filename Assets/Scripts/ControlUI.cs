using UnityEngine;

public class ControlUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject parentObject;
    void Start()
    {
        
        parentObject = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            parentObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}
