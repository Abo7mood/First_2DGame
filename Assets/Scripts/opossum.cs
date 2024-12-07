using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opossum : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    [SerializeField]
    float speed;

    bool isRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) <= 0.01f)
        {
            isRight = !isRight;
            sr.flipX = !sr.flipX;
        }
        if (isRight)
            rb.velocity = new Vector2(Time.fixedDeltaTime * speed, rb.velocity.y);
        else 
            rb.velocity = new Vector2(Time.fixedDeltaTime * speed *-1, rb.velocity.y);

    }
}
