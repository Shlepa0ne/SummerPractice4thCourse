using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static Unity.VisualScripting.Antlr3.Runtime.Tree.TreeWizard;
using static UnityEngine.EventSystems.EventTrigger;

public class BurgerManager : MonoBehaviour
{
    AutoMovingCube autoMovingCube;
    MovingVisitor movingVisitor;
    VisitorSpawner visitorSpawner;
    private Vector3 burgerOnHead;
    private int timer = 0;
    private bool orderDone = false;

    private void Start()
    {
        autoMovingCube = FindObjectOfType<AutoMovingCube>();
        visitorSpawner = FindObjectOfType<VisitorSpawner>();
    }

    private void FixedUpdate()
    {
        MovingVisitor movingVisitor = visitorSpawner.visitors[0].GetComponent<MovingVisitor>();

        if (!orderDone)
        {
            burgerOnHead = GameObject.Find("BurgerOnHead").transform.position;
            if (!autoMovingCube.putBurgerDown)
            {
                timer++;
                if (timer > 20)
                {
                    transform.position = burgerOnHead;
                    autoMovingCube.burgerIsTaken = true;
                }
            }
            else if (timer > 20)
                timer = 0;
            else if (autoMovingCube.putBurgerDown)
            {
                timer++;
                if (timer > 20)
                {
                    transform.position = ChairManager.burgerPoint[autoMovingCube.occupiedChairs[0]].transform.position;
                    //Debug.Log(autoMovingCube.occupiedChairs[0]);
                    autoMovingCube.orderDone = true;
                    orderDone = true;
                    timer = 0;
                }
            }
        }
        else
        {
            timer++;
            if (timer > 30)
            { 
                Destroy(gameObject);
                movingVisitor.orderDone = true;
                visitorSpawner.visitors.RemoveAt(0);
            }
        }
    }
}
