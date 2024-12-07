using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    Rigidbody2D  rb;
    
    public float speed;


    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Right()
    {
        rb.velocity = new Vector2(speed,rb.velocity.y);

    }
}
