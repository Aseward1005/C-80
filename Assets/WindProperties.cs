using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

//wind keeps track of all items inside its box.
//When it is active, it applies a force to everything inside it
//It keeps track of its direction (wasd)
public class WindProperties : MonoBehaviour
{
    //I don't know that we need to keep track whether the wind is active, it just pushes when it is
    //The spell handler will just call push on the wind object
    public bool active;

    public List<GameObject> objectsInside;
    public float strength = 10f;

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
    public void Push(Vector2 direction)
    { 
        foreach (GameObject obj in objectsInside) 
        {
            if (obj.TryGetComponent<Rigidbody2D>(out var body))
            {
                body.AddRelativeForce(direction * strength);
            }
        }
    }

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
}
