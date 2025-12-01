using UnityEngine;

public class PaperPuzzle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        // Get mouse position in screen space
        Vector3 mousePos = Input.mousePosition;

        // Convert to world space
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        // Set z to 0 (since it's 2D)
        mousePos.z = 0f;

        // Move object to mouse position
        transform.position = mousePos;
        // Rotate object to "normal" direction
        transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), Time.deltaTime * 3);
    }
}