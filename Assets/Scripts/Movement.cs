using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(new Vector3(-0.03f, 0)); 
    

    //Debug.Log(myVariable + x);
}

    // Update is called once per frame
    void Update()
    {
       GetComponent<Transform>().Translate(new Vector3(-0.03f, 0));
    }  


}
  
   

