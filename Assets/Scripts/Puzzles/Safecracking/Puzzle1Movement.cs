using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle1Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject lockMechanism;
    [SerializeField] private Transform tilemapTransform;

    [SerializeField] private Transform verticalCast;
    [SerializeField] private LayerMask whatIsTilebox;

    private Rigidbody2D rb;
    
    public float speed = 1.0f;
    private Vector3 previousPos;
    private float verticalRay = 1f;

    private bool isMoving;

    void Start()
    {
        isMoving = false;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveDir();

        CheckBox();
        
    }
    protected bool keepMoving()
    {
        if (rb.linearVelocity != new Vector2(0,0))
        {
            return true;
        }
        return false;
    }

    protected void MoveDir()
    {
        if (Mathf.RoundToInt(tilemapTransform.localRotation.eulerAngles.z/90) * 90 == Mathf.RoundToInt(tilemapTransform.localRotation.eulerAngles.z)) {
            rb.gravityScale = 1;
        }
        else {
            rb.gravityScale = 0;
        }
    
    }

    public void SetIsMoving() {
        if(!isMoving) {
            isMoving = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        lockMechanism.GetComponent<Vaultlock>().NextLock();
    }

    public void CheckBox() {
        RaycastHit2D upHit = Physics2D.Raycast(verticalCast.position, Vector2.down, verticalRay, whatIsTilebox);

        Debug.DrawRay(verticalCast.position, Vector2.down * verticalRay, Color.blue, 1.0f);

        if(upHit.collider != null && upHit.collider.CompareTag("Tilebox") && isMoving
        && Mathf.RoundToInt(tilemapTransform.localRotation.eulerAngles.z/90) * 90 == Mathf.RoundToInt(tilemapTransform.localRotation.eulerAngles.z)
        && ((rb.linearVelocity.x >= 0.01 || rb.linearVelocity.x <= -0.01)
        || (rb.linearVelocity.y >= 0.01 || rb.linearVelocity.y <= -0.01))) {
            SoundManager.PlaySound(SoundManager.Sound.CogwheelPlace);
            isMoving = false;
        }
    }

}
