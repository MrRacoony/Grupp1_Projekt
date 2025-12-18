using UnityEngine;

public class ObjectPickup : MonoBehaviour
{

    [SerializeField] private string objectName;
    [SerializeField] private GameObject inventory;

    private void OnMouseDown() {
        inventory = GameObject.Find("Inventory");
        
        if (GetComponent<DialogueTrigger>() != null)
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        
        SoundManager.PlaySound(SoundManager.Sound.ItemPickup);

        if(inventory != null) {
            inventory.GetComponent<InventorySystem>().AddObject(objectName);
        }

        Destroy(this.gameObject);
    }

}
