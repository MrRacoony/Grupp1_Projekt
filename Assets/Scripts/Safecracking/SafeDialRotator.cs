using UnityEngine;

public class SafeDialRotator : MonoBehaviour
{

    [SerializeField] private Transform tilemapTransform;

    public float degreesPerSec = 90f;
    private float rotAmount, curRot;

    private bool isRotatingLeft = false;
    private bool isRotating;

    float speed = 1f;
    float timeCount = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, rotAmount)), Time.deltaTime * 5);
        tilemapTransform.localRotation = Quaternion.Slerp(tilemapTransform.rotation, Quaternion.Euler(new Vector3(0, 0, rotAmount)), Time.deltaTime * 5);
    }

    public void Rotate(float degrees) {
        float rotateTo = Mathf.RoundToInt(transform.localRotation.eulerAngles.z/90) * 90;
        rotAmount = rotateTo + degrees;
    }
}
