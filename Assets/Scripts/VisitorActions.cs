using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VisitorActions : MonoBehaviour
{
    public MovingVisitor movingVisitor;
    private int chairNumber;

    void Start()
    {
        chairNumber = movingVisitor.ChairNumber;        
    }


    void FixedUpdate()
    {
        if (ChairManager.chairPassed[chairNumber] == true)
        {

        }
    }
}
