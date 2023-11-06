using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Combo 
{
    public string[] buttons;
    public int counter;
    public int len;
    public Combo(string[] buttonOrder)
    { 
        buttons = buttonOrder;
        counter = 0;
        len = buttonOrder.Length;
    }

    public bool checkButton() 
    {
        if (Input.GetButtonDown(buttons[counter]))
        {
            counter++;
            if (counter == len)
            {
                counter = 0;
                return true;
            }
        }

        else
        {
            counter = 0;
        }

        return false;
    }
}

public class SpellController : MonoBehaviour
{
    public WindProperties Wind;
    public TeleportProperties Teleport;
    public FireLauncher Fire;
    public Vector3 dir;

    private Combo windCombo = new(new string[] { "Spell1", "Spell2", "Spell3" });
    private Combo fbCombo = new(new string[] { "Spell1", "Spell3", "Spell4", "Spell2", "Spell6" });
    private Combo tpCombo = new(new string[] {"Spell3", "Spell1", "Spell6", "Spell4"});

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
        /*
        if (Input.GetButtonDown("Spell1") == true)
            Wind.Push(dir);
        if (Input.GetButtonDown("Spell2") == true)
            Teleport.teleport(dir);
        if (Input.GetButtonDown("Spell3") == true)
            Fire.fire(dir);
        */
        if (spellButtonDown())
        {
            if (windCombo.checkButton())
                Wind.Push(dir);
            if (fbCombo.checkButton())
                Fire.fire(dir);
            if (tpCombo.checkButton())
                Teleport.teleport(dir);
        }

    }

    bool spellButtonDown()
    {
        if (Input.GetButtonDown("Spell1") || Input.GetButtonDown("Spell2") || Input.GetButtonDown("Spell3") || Input.GetButtonDown("Spell4") || Input.GetButtonDown("Spell5") || Input.GetButtonDown("Spell6"))
            return true;
        else 
            return false;

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
