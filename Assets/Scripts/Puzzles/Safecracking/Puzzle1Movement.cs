using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle1Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject lockMechanism;
    [SerializeField] private Transform tilemapTransform;

    private Rigidbody2D rb;
    
    public float speed = 1.0f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveDir();
        
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

    private void OnTriggerEnter2D(Collider2D other) {
        lockMechanism.GetComponent<Vaultlock>().NextLock();
    }

}
