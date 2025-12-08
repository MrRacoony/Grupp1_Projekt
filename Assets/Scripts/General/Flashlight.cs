using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour
{

    private float mouseXPos;
    private float minX;
    private float maxX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minX = 0;
        maxX = Screen.width;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mouseXPos =  Mathf.Clamp(mousePos.x, minX, maxX);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseXPos, mousePos.y, Camera.main.nearClipPlane));

        transform.position = new Vector2(worldPos.x, worldPos.y);
        
    }

    

}
