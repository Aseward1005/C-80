using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProperties : MonoBehaviour
{
    public float size;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void explode()
    {
        //detect what objects are inside
        Collider2D[] toDamage = Physics2D.OverlapCircleAll(transform.position, size);

        //destroy all things in the radius that can be destroyed
        foreach (Collider2D col in toDamage)
        {
            if (col.gameObject.CompareTag("Destructable"))
            {
                Destroy(col.gameObject);
            }
        }

        //eliminate self
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        explode();
    }
}
