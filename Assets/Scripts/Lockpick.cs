using UnityEngine;

public class Lockpick : MonoBehaviour
{

    [SerializeField] private Transform verticalCast;

    private Rigidbody2D rgbd;
    private float mouseXPos;
    public float minX;
    public float maxX;
    private float verticalRay = 1.35f;

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

        transform.position = new Vector2(worldPos.x, transform.position.y);

        if (Input.GetMouseButtonDown(0)) {
            CheckLock();
        }
        
    }

    private void CheckLock() {
        RaycastHit2D upHit = Physics2D.Raycast(verticalCast.position, Vector2.up, verticalRay);

        Vector2 origin = verticalCast.position;
        Debug.DrawRay(origin, Vector2.up * verticalRay, Color.red);

        if(upHit.collider != null && upHit.collider.CompareTag("Lock")) {
            
        }
    }

}
