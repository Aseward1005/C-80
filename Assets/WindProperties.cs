using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

//wind keeps track of all items inside its box.
//When it is active, it applies a force to everything inside it
//It keeps track of its direction (wasd)
public class WindProperties : MonoBehaviour
{
    //public List<GameObject> objectsInside;
    public float strength;
    public Vector3 size;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //I don't know that update even needs to be called, we just need the push method
    void Update()
    {
        //I was gonna track the direction here but that's inefficient, I should do it in the spell handler
    }

    //move all the objects inside in the direction you pass in
    public void Push(Vector3 direction)
    {
        //new way. check what to push when its time to push. This also pushes the player though most likely
        Collider2D[] toPush = Physics2D.OverlapBoxAll(transform.position, size, 0f);
        foreach (Collider2D collision in toPush) 
        {
            GameObject obj = collision.gameObject;
            if (obj.TryGetComponent<Rigidbody2D>(out var body))
            {
                body.AddRelativeForce(direction * strength);
            }
        }
    }

    //old way, hold when something collides with the persistent box
    /*
    //Keeps track of what items are within the bounds of the wind box
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!objectsInside.Contains(collision.gameObject)) 
        {
            objectsInside.Add(collision.gameObject);

            Debug.Log("Added" + collision.gameObject.name);
            Debug.Log("Objects inside wind box:" + objectsInside.Count);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (objectsInside.Contains(collision.gameObject)) 
        {
            objectsInside.Remove(collision.gameObject);

            Debug.Log("Removed" + collision.gameObject.name);
            Debug.Log("Objects inside wind box:" + objectsInside.Count);
        }
    }
    */
}
