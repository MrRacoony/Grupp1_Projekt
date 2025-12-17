using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        gameObject.transform.position = new Vector2(mousePos.x, mousePos.y);
    }
}
