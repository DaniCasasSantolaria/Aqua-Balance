using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour{

    [SerializeField] private float initialX;
    [SerializeField] private float initialY;

    [SerializeField] private float speed;
    private float horizontal;
    bool isFacingRight;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(initialX, initialY);
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update() {
        GetInput();
        Move();
    }

    public void Move() {
        Flip();
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void GetInput() {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void Flip() {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
