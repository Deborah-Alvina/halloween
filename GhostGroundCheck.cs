using UnityEngine;

public class GhostGroundCheck : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private float gracePeriod = 2.5f;

    public LogicScript logic;
    public bool over = false;

    private float notGroundedTime = 0f;

    void Start()
    {
        logic = FindObjectOfType<LogicScript>();
        if (anim != null)
            anim.enabled = true;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance) ||
               Physics.Raycast(transform.position, Vector3.up, groundCheckDistance);
    }

    void FixedUpdate()
    {
        if (IsGrounded())
        {
            notGroundedTime = 0f;

            rb.useGravity = false;
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (anim != null)
                anim.enabled = true;
        }
        else
        {
            notGroundedTime += Time.fixedDeltaTime;

            if (notGroundedTime >= gracePeriod)
            {
                if (logic != null)
                {
                    over = true;
                    logic.gameOver();
                }
            }

            rb.useGravity = true;

            if (anim != null)
                anim.enabled = false;
        }
    }
}