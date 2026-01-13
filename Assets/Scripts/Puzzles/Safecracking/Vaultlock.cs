using UnityEngine;

public class Vaultlock : MonoBehaviour
{

    [SerializeField] private GameObject lock1, lock2, lock3, lockUnlocked1, lockUnlocked2, lockUnlocked3;
    [SerializeField] private GameObject puzzleOverlay, safeOpen, safeClosed;

    private int lockNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lockNum = 0;
        lock1.SetActive(true);
        lock2.SetActive(false);
        lock3.SetActive(false);
        lockUnlocked1.SetActive(false);
        lockUnlocked2.SetActive(false);
        lockUnlocked3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLockNum() {
        return lockNum;
    }

    public void NextLock() {
        lockNum++;
        if(lockNum == 1) {
            SoundManager.PlaySound(SoundManager.Sound.SafeClick);
            lock1.SetActive(false);
            lock2.SetActive(true);
            lock3.SetActive(false);
            lockUnlocked1.SetActive(true);
        }
        else if(lockNum == 2) {
            SoundManager.PlaySound(SoundManager.Sound.SafeClick);
            lock1.SetActive(false);
            lock2.SetActive(false);
            lock3.SetActive(true);
            lockUnlocked2.SetActive(true);
        }
        else if(lockNum == 3) {
            SoundManager.PlaySound(SoundManager.Sound.SafeClick);
            SoundManager.PlaySound(SoundManager.Sound.SafeOpen);
            puzzleOverlay.SetActive(false);
            safeOpen.SetActive(true);
            safeClosed.SetActive(false);
        }
    }

}
