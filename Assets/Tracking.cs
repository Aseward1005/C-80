using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    public GameObject trackingTarget;
    public float updateSpeed;
    private Vector3 offset;
    public Vector2 trackingOffset;

    // Set an offset if applicable
    void Start()
    {
        offset = (Vector3)trackingOffset;
        offset.z = transform.position.z - trackingTarget.transform.position.z;
    }

    //fixed update for smooveness
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, trackingTarget.transform.position + offset, updateSpeed * Time.deltaTime);
    }
}
