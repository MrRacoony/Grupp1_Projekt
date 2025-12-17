using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{

    private bool isOn;
    private bool started;
    
    private float mouseXPos, mouseYPos;
    private float minX, maxX;
    private float minY, maxY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isOn = false;
        started = false;
        minX = 0;
        maxX = Screen.width;
        minY = 0;
        maxY = Screen.height;
        //Cursor.visible = false;
        GetComponent<Light2D>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            started = true;
            StartCoroutine(StartLight());
        }
        if (isOn)
        {
        GetComponent<Light2D>().enabled = true;
        Vector3 mousePos = Input.mousePosition;
        mouseXPos =  Mathf.Clamp(mousePos.x, minX, maxX);
        mouseYPos =  Mathf.Clamp(mousePos.y, minY, maxY);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseXPos, mouseYPos, Camera.main.nearClipPlane));

        transform.position = new Vector2(worldPos.x, worldPos.y);
        }
        else
        {
            GetComponent<Light2D>().enabled = false;
        }
        
        
    }

    private IEnumerator StartLight()
    {
        var child = GetComponent<DialogueTrigger>();
        var parent = transform.parent.GetComponent<DialogueTrigger>();

        yield return child.TriggerDialogue();
        isOn = true;
        SoundManager.PlaySound(SoundManager.Sound.FlashlightClick);
        yield return parent.TriggerDialogue();
    }




}
