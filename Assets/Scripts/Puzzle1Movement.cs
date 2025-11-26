using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle1Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject lockMechanism;

    private Rigidbody2D rb;
    
    public float speed = 1.0f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!keepMoving())
        {
            MoveDir();
        }
        
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

        //temporary movement
        if (Input.GetKey(KeyCode.W))
        {
            rb.linearVelocity = new Vector2(0,1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-1, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocity = new Vector2(0, -1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(1, 0);
        }

        rb.linearVelocity *= speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        lockMechanism.GetComponent<Vaultlock>().NextLock();
    }

}
