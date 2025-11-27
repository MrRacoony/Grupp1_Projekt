using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                Debug.Log("Ray casted");
                if (raycastHit.transform != null)
                {
                    Debug.Log("Clicked" + raycastHit.transform.gameObject);
                    //Our custom method. 
                    //CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }

    }
}
