using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject2 : MonoBehaviour
{
    [Header("UnitySetup")]
    public float time;
    // Start is called before the first frame update
    void Start()
    {
    
        Destroy(gameObject, time);

    }
}

