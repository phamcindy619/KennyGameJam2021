using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float moveLimiter = 0.7f;
    
    private float h, v;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");


    }

    private void FixedUpdate() {
        // Moving diagonally
        if (h != 0 && v != 0) {
            // Limit diagonal movement speed
            h *= moveLimiter;
            v *= moveLimiter;
        }

        rb.velocity = new Vector2(h * speed, v * speed);

        if (rb.velocity != Vector2.zero) {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }  
}
