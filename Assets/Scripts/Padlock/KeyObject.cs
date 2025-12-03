using UnityEngine;

public class KeyObject : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnMouseDown() {
        Destroy(this.gameObject);
    }

}
