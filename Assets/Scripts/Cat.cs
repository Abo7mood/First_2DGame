using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Cat : MonoBehaviour
{


    Rigidbody2D rb;
    float dirX;
    [SerializeField]
    float moveSpeed = 5f, jumpForce = 500f;
    bool jumpAllowed, wallJumpAllowed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;

        if (rb.velocity.y == 0 || wallJumpAllowed)
            jumpAllowed = true;
        else
            jumpAllowed = false;

        if (CrossPlatformInputManager.GetButtonDown("Jump") && jumpAllowed)
            DoJump();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void DoJump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Wall"))
        {
            wallJumpAllowed = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Wall"))
            wallJumpAllowed = false;
    }

}
