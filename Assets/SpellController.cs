using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public WindProperties Wind;
    public TeleportProperties Teleport;
    public FireLauncher Fire;
    public Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        /*
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");
        */
        setDirection(x, y);

        //string handling not added yet
        if (Input.GetButtonDown("Spell1") == true)
            Wind.Push(dir);
        if (Input.GetButtonDown("Spell2") == true)
            Teleport.teleport(dir);
        if (Input.GetButtonDown("Spell3") == true)
            Fire.fire(dir);
    }

    void setDirection(float x, float y)
    {
        dir.x = 0;
        dir.y = 0;

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
