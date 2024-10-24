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
    float coyoteTimeCounter = COYOTE_TIME;

    //Buffer Jump
    const float BUFFER_TIME = 0.13f;
    float bufferTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.red);
        JumpInput();
    }

    private void JumpInput() {
        CoyoteTime();
        BufferJump();
        _Jump();
    }

    private void _Jump()
    {
        if (bufferTimer > 0f && coyoteTimeCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            bufferTimer = 0f;
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f; 
        }
    }

    private void BufferJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            bufferTimer = BUFFER_TIME;
        }
        else
        {
            bufferTimer -= Time.deltaTime;
        }
    }

    private void CoyoteTime()
    {
        if (!IsGrounded())
            coyoteTimeCounter -= Time.deltaTime;
        else
        {
            coyoteTimeCounter = COYOTE_TIME;
        }
    }

    private bool IsGrounded() {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer);
    }
}
