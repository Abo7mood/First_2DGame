using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchscript : MonoBehaviour
{
    Rigidbody2D rb;
    private float movespeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movespeed = 10f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case  TouchPhase.Began:
                    if (touch.position.x < Screen.width / 2)
                        rb.velocity = new Vector2(-movespeed, 0f);

                    if (touch.position.x > Screen.width / 2)
                        rb.velocity = new Vector2(movespeed, 0f);

                    break;

                case TouchPhase.Ended:

                    rb.velocity = new Vector2(0f, 0f);
                    break;




            }
        }


        }
    }

