using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : LivingObject
{
    public bool isClimbable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void BringLife()
    {
        isAlive = true;
        isClimbable = true;
        //Animation that activates the ladder.
    }

    protected override void BringDeath()
    {
        isAlive = false;
        isClimbable = false;
        //Animation that kills the ladder.
    }
}
