using UnityEngine;

public class ObjectPickup : MonoBehaviour
{

    [SerializeField] private string objectName;
    [SerializeField] private GameObject inventory;

    private void OnMouseDown() {
        SoundManager.PlaySound(SoundManager.Sound.ItemPickup);
        inventory.GetComponent<InventorySystem>().AddObject(objectName);
        Destroy(this.gameObject);
    }

}
