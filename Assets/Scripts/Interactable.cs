using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Interactable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject uiChild;
    private SpriteRenderer render;


    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        if (transform.childCount == 1)
        {
            uiChild = transform.GetChild(0).gameObject;
        }
        else
        {
            Debug.LogError(this + " is required to have 1 children, you have " + transform.childCount);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    if (raycastHit.transform == this.transform)
                    {
                        //OpenChildren
                    }
                    //Our custom method. 
                    //CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
            
        }

    }

    private void OnMouseOver()
    {
        render.color = new Color(0, 255, 255);
    }
    private void OnMouseDown()
    {
        render.color = new Color(255, 255, 255);
        render.enabled = false;
        uiChild.SetActive(true);
    }
    private void OnMouseExit()
    {
        render.color = new Color(255, 255, 255);
    }
}
