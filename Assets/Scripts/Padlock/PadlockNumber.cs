using UnityEngine;

public class PadlockNumber : MonoBehaviour
{

    [SerializeField] private int correctNum;

    private int currentNum;
    
    private bool isCorrect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentNum = 0;
        if(currentNum == correctNum) {
            isCorrect = true;
        }
        else {
            isCorrect = false;
        }
    }

    public bool GetIsCorrect() {
        return isCorrect;
    }

    public void SetNum(int num) {
        currentNum += num;
        if(currentNum == 10) {
            currentNum = 0;
        }
        if(currentNum == -1) {
            currentNum = 9;
        }
        if(currentNum == correctNum) {
            isCorrect = true;
            Debug.Log("Unlocked padlock!");
        }
        else {
            isCorrect = false;
        }
    }
}
