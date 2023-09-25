using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public WindProperties Wind;
    public Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        setDirection(x, y);

        //string handling not added yet
        if (Input.GetAxis("Spell1") > 0)
            Wind.Push(dir);
    }

    void setDirection(float x, float y)
    {
        if (x > 0)
            dir.x = 1;
        else if (x < 0)
            dir.x = -1;

        if (y > 0)
            dir.y = 1;
        else if (y < 0)
            dir.y = -1;
    }
}
