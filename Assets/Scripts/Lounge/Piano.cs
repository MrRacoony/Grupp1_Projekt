using UnityEngine;

public class Piano : MonoBehaviour
{

    private int minInt = 0;
    private int maxInt = 7;
    private int key;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnMouseDown() {
        key = Random.Range(minInt, maxInt);

        if(key == 0) {
            SoundManager.PlaySound(SoundManager.Sound.Piano_A);
        }
        else if(key == 1) {
            SoundManager.PlaySound(SoundManager.Sound.Piano_B);
        }
        else if(key == 2) {
            SoundManager.PlaySound(SoundManager.Sound.Piano_C);
        }
        else if(key == 3) {
            SoundManager.PlaySound(SoundManager.Sound.Piano_D);
        }
        else if(key == 4) {
            SoundManager.PlaySound(SoundManager.Sound.Piano_E);
        }
        else if(key == 5) {
            SoundManager.PlaySound(SoundManager.Sound.Piano_F);
        }
        else if(key == 6) {
            SoundManager.PlaySound(SoundManager.Sound.Piano_G);
        }
        

    }
}
