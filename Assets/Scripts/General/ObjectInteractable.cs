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
        SoundManager.PlaySound(SoundManager.Sound.UIClick);
        layer.SetActive(true);

    }

    public void CloseLayer() {
        layer.SetActive(false);
    }

}
