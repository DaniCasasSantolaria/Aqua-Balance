using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    [SerializeField] private float jumpingPower;
    [SerializeField] private float fallingPower;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    Vector2 vecGravity;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        vecGravity = new Vector2(0f, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Jump();
    }

    private void _Jump() {
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);   
        }

        if(rb.velocity.y < 0f)
        {
            rb.velocity -= vecGravity * fallingPower * Time.deltaTime;
        }
    }

    private bool isGrounded() {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.8f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}
