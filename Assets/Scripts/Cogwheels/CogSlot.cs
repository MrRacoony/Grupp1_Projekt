using UnityEngine;

public class CogSlot : MonoBehaviour
{

    private bool isOccupied;

    void Start() {
        isOccupied = false;
    }

    public void SetOccupied(bool input) {
        isOccupied = input;
    }

    public bool GetIsOccupied() {
        return isOccupied;
    }


}
