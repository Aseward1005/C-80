using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMoves : MonoBehaviour
{
    public Vector3 movespeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = movespeed;
    }
}
