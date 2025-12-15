using NUnit.Framework;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class DragableObject : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        
        
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        SoundManager.PlaySound(SoundManager.Sound.Paperslide); 

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        
    }
    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), Time.deltaTime * 5);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

    private void Update()
    {
            // Convert world position to viewport space (0..1 range)
            Vector2 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

            // Clamp inside the viewport
            //viewportPos.x = Mathf.Clamp(viewportPos.x, 0f, 1f);
            //viewportPos.y = Mathf.Clamp(viewportPos.y, 0f, 1f);

        Vector2 targetPos = Camera.main.ViewportToWorldPoint(viewportPos);
        // Convert back to world space
        transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);
    }
}
