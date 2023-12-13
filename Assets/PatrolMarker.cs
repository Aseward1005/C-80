using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMarker : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this will break if we add different movement patterns
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == enemy)
            enemy.GetComponent<GoombaMoves>().movespeed *= -1;
    }
}
