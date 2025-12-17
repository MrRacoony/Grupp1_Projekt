using UnityEngine;

public class ObjectInteractable : MonoBehaviour
{

    [SerializeField] private GameObject layer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnMouseDown() {
        layer.SetActive(true);
        gameObject.SetActive(false);

    }

    public void CloseLayer() {
        layer.SetActive(false);
        gameObject.SetActive(true);

    }

}
