using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TeleportProperties : MonoBehaviour
{
    public GameObject Target;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void teleport(Vector3 dir)
    {
        Target.transform.position += dir * distance;
    }
}

