using UnityEngine;

public class Vaultlock : MonoBehaviour
{

    [SerializeField] private GameObject lock1, lock2, lock3;

    private int lockNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lockNum = 0;
        lock1.SetActive(true);
        lock2.SetActive(false);
        lock3.SetActive(false);
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
            lock1.SetActive(false);
            lock2.SetActive(true);
            lock3.SetActive(false);
        }
        else if(lockNum == 2) {
            lock1.SetActive(false);
            lock2.SetActive(false);
            lock3.SetActive(true);
        }
        else if(lockNum == 3) {
            
        }
    }

}
