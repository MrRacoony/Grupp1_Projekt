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
        isCorrect = false;
    }

    public bool GetIsCorrect() {
        return isCorrect;
    }

    public void SetNum(int num) {
        currentNum += num;
        if(currentNum == correctNum) {
            isCorrect = true;
        }
        else {
            isCorrect = false;
        }
    }
}
