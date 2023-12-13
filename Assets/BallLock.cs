using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallLock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    public GameObject ball;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == ball)
            Destroy(door);
    }
}
