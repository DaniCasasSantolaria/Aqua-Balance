using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    [SerializeField] private float jumpingPower;
    [SerializeField] private LayerMask groundLayer;

    Rigidbody2D rb;

    //Coyote Time
    const float COYOTE_TIME = 0.2f;
    float fallTimer = COYOTE_TIME;
    bool justJumped = false;

    //Buffer Jump
    const float BUFFER_TIME = 0.1f;
    bool hasBufferedJump = false;
    float sinceBufferedJump = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpInput();
    }

    private void JumpInput() {
        CoyoteTime();
        BufferJump();
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            _Jump();
    }

    private void _Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }

    private void BufferJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded())
        {
            hasBufferedJump = true;
            sinceBufferedJump = 0f;
        }

        if(hasBufferedJump)
        {
            sinceBufferedJump += Time.deltaTime;
            if(sinceBufferedJump >= BUFFER_TIME)
            {
                sinceBufferedJump = 0f;
                hasBufferedJump = false;
            }
        }

        if(hasBufferedJump && IsGrounded())
        {
            _Jump();
            hasBufferedJump = false;
            sinceBufferedJump = 0f;
        }
    }

    private void CoyoteTime()
    {
        if (!IsGrounded())
            fallTimer -= Time.deltaTime;
        else
        {
            fallTimer = COYOTE_TIME;
            justJumped = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && !justJumped && fallTimer > 0f)
        {
            _Jump();
            justJumped = true;
        }


    }

    private bool IsGrounded() {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer);
    }
}
