using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
  
    public bool isFire;
    SpriteRenderer s;
        
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetFire", 0.01f, 10f);
        s = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
      
        if (isFire==true)
        {
            s.enabled = true;
        }
        if (isFire == false)
        {
            s.enabled = false;
        }









    }

    IEnumerator Fire()
    {
        isFire =true;
        yield return new WaitForSeconds(2f);
        isFire = false;
    }
    public void GetFire()
    {
        StartCoroutine(Fire());
    }

 

}
