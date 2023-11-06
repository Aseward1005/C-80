using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLauncher : MonoBehaviour
{
    public float speed;
    public float offset;

    public GameObject fireball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //launch a fireball in a straight line
    public void fire(Vector3 dir)
    {
        GameObject f = Instantiate(fireball, transform.position + dir*offset, transform.rotation);
        f.GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
}
