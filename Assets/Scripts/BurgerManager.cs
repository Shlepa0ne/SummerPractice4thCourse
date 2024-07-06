using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.EventSystems.EventTrigger;

public class BurgerManager : MonoBehaviour
{
    BurgerSpawner burgerSpawner;
    AutoMovingCube autoMovingCube;
    private Vector3 burgerOnHead;
    private int timer = 0;

    private void Start()
    {
        burgerSpawner = FindObjectOfType<BurgerSpawner>();
        autoMovingCube = FindObjectOfType<AutoMovingCube>();
    }

    private void FixedUpdate()
    {
        if (!autoMovingCube.orderDone)
        {  
            burgerOnHead = GameObject.Find("BurgerOnHead").transform.position;
            if (burgerSpawner.isSpawn && !autoMovingCube.putBurgerDown)
            {
                timer++;
                if (timer > 20)
                {
                    transform.position = burgerOnHead;
                    autoMovingCube.burgerIsTaken = true;
                    timer = 20;
                }
            }
            else if (autoMovingCube.putBurgerDown)
            {
                timer--;
                if (timer < 0)
                {
                    transform.position = ChairManager.burgerPoint[autoMovingCube.occupiedChairs[0]].transform.position;
                    autoMovingCube.orderDone = true;
                }
            }
        }
    }
}
