using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : MonoBehaviour
{
    public float forceY = 300f;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
            
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack ());
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 4));
        forceY = Random.Range(250, 550);
        myRigidbody.AddForce(new Vector2(0, forceY));
        myAnimator.SetBool("attack", false);
        StartCoroutine(Attack());
    }

    


        
    
        
    



















    // Update is called once per frame
    void Update()

{

  
    }
}

