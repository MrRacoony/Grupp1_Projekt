using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour
{

    private bool isOn;
    
    private float mouseXPos, mouseYPos;
    private float minX, maxX;
    private float minY, maxY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minX = 0;
        maxX = Screen.width;
        minY = 0;
        maxY = Screen.height;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mouseXPos =  Mathf.Clamp(mousePos.x, minX, maxX);
        mouseYPos =  Mathf.Clamp(mousePos.y, minY, maxY);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseXPos, mouseYPos, Camera.main.nearClipPlane));

        transform.position = new Vector2(worldPos.x, worldPos.y);
        
    }

    

}
