using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitcher : MonoBehaviour
{
    public float maxVelocity;
    public float gravityScale;

    public float verticalDirection;
    public float horizontalDirection;

    public int direction = 1;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        CheckGravity();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().Play("Gravity");

            CheckGravity();
        }
    }

    private void FixedUpdate()
    {
        if(Mathf.Abs( rb.velocity.x) < maxVelocity && Mathf.Abs( rb.velocity.y) < maxVelocity)
        {
            rb.AddForce(new Vector2(gravityScale * horizontalDirection, gravityScale * verticalDirection));
        }

        if (direction == 1 || direction == 3)
        {
            if (Mathf.Abs(rb.velocity.y) > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Lerp(rb.velocity.y, 0, .1f));
            }
        }

        if (direction == 2 || direction == 4)
        {
            if (Mathf.Abs(rb.velocity.x) > 0)
            {
                rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, .1f), rb.velocity.y);
            }
        }
    }

    void CheckGravity()
    {
        switch (direction)
        {
            //down
            case 1:
                horizontalDirection = 0;
                verticalDirection = -1;
                direction++;
                break;
            //right
            case 2:
                verticalDirection = 0;
                horizontalDirection = 1;
                direction++;
                break;
            //up
            case 3:
                horizontalDirection = 0;
                verticalDirection = 1;
                direction++;
                break;
            //left
            case 4:
                verticalDirection = 0;
                horizontalDirection = -1;
                direction = 1;
                break;

        }
    }
}
