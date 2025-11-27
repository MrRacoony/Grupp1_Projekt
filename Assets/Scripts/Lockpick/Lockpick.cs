using UnityEngine;

public class Lockpick : MonoBehaviour
{

    [SerializeField] private Transform verticalCast;
    [SerializeField] private LayerMask whatAreLocks;

    private Rigidbody2D rgbd;
    private float mouseXPos;
    public float minX;
    public float maxX;
    private float verticalRay = 0.5f;
    
    private int currentLock = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mouseXPos =  Mathf.Clamp(mousePos.x, minX, maxX);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseXPos, mousePos.y, Camera.main.nearClipPlane));

        Vector2 origin = verticalCast.position;
        Debug.DrawRay(origin, Vector2.up * verticalRay, Color.red);

        transform.position = new Vector2(worldPos.x, transform.position.y);

        if (Input.GetMouseButtonDown(0)) {
            CheckLock();
        }
        
    }

    private void CheckLock() {
        RaycastHit2D upHit = Physics2D.Raycast(verticalCast.position, Vector2.up, verticalRay, whatAreLocks);

        if(upHit.collider != null && upHit.collider.CompareTag("Lock")) {
            if(upHit.collider.GetComponent<Lock>().isUnlocked == false) {
                if(GameObject.ReferenceEquals(upHit.collider.transform.parent.GetComponent<LockOrder>().lockOrder[currentLock], upHit.collider.gameObject)) {
                    currentLock++;
                    upHit.collider.transform.position = new Vector2(upHit.collider.transform.position.x, 1.0f);
                    upHit.collider.GetComponent<Lock>().SetUnlocked(true);
                    Debug.Log("Has unlocked it");
                }
                else {
                    upHit.collider.transform.parent.GetComponent<LockOrder>().SetLocked();
                    currentLock = 0;
                    Debug.Log("Has locked all");
                }
            }
            
        }
    }

}
