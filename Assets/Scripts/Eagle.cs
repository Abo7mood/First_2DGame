using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{




    [SerializeField]
    Transform player;
    [SerializeField]
    float EagleHieght =2; 
    SpriteRenderer sr;
    Vector3 startpos;
    [SerializeField]
    float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        startpos = transform.position;
        StartCoroutine(EagleAnimation());
        




    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > transform.position.x)
            sr.flipX = true;
        else
            sr.flipX = false;





    }
    IEnumerator EagleAnimation()
    {
        Vector3 endpos = new Vector3(startpos.x, startpos.y + EagleHieght, startpos.z);
        bool isFlight = true;
        float value = 0;
            while (true)
        {

            yield return null;
            //Debug.Log("yes");
            if (isFlight)
                transform.position = Vector3.Lerp(startpos, endpos, value);
            else
                transform.position = Vector3.Lerp(endpos, startpos, value);

            value = value + Time.deltaTime * speed; 
            if(value >1)
            {
                value = 0;
                isFlight = !isFlight;


}
             


        }

 
    }


}
