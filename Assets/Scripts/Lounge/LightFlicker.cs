using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    
    [SerializeField] private string nextScene;
    [SerializeField] private GameObject inventory, safeObject, navCollider;

    private float minTime = 0.2f;
    private float maxTime = 0.6f;
    private float targetTime;
    private float targetVolume = 0f;

    private int flickerCount = 0;

    private bool isActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetTime = 0.2f;
        inventory = GameObject.Find("Inventory");
    }

    // Update is called once per frame
    void Update()
    {

        if(inventory != null && !isActive) {
            if(inventory.GetComponent<InventorySystem>().HasObject("FinalKey")) {
                isActive = true;
                SoundManager.PlaySound(SoundManager.Sound.Monster);
                SoundManager.SetVolume(SoundManager.Sound.Monster, 0f);
                navCollider.SetActive(false);
                safeObject.SetActive(false);
            }
        }

        if(targetTime > 0f && isActive) {
            targetTime -= Time.deltaTime;
            if(targetVolume < 1f) {
                targetVolume += 0.001f;
                SoundManager.SetVolume(SoundManager.Sound.Monster, targetVolume);
            }
            if(targetTime <= 0f) {
                if(transform.GetChild(0).gameObject.activeSelf) {
                    transform.GetChild(0).gameObject.SetActive(false);
                    targetTime = 0.2f;
                }
                else {
                    transform.GetChild(0).gameObject.SetActive(true);
                    targetTime = Random.Range(minTime, maxTime);
                }
                flickerCount++;
                if(flickerCount >= 20) {
                    SoundManager.StopSound(SoundManager.Sound.Ambience3);
                    SoundManager.StopSound(SoundManager.Sound.Monster);
                    SoundManager.PlaySound(SoundManager.Sound.ScaryShock);
                    SceneController.OpenSceneAddition(nextScene);
                }
            }
        }
    }

    public void SetIsActive() {
        isActive = true;
    }

}
