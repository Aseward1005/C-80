using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetThrough : MonoBehaviour
{
    public GameObject pass;
    public GameObject pass2;
    // Start is called before the first frame update
    void Start()
    {
        Collider2D[] arr = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D col in arr)
        {
            Physics2D.IgnoreCollision(pass.GetComponent<Collider2D>(), col);
            Physics2D.IgnoreCollision(pass2.GetComponent<Collider2D>(), col);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
    }
}
