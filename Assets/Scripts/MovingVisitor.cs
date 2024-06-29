using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingVisitor : MonoBehaviour
{
    [SerializeField] private float speed = 13f;
    [SerializeField] private float turnSmoothTime = 0.06f;
    private float turnSmoothVelocity;

    private Rigidbody rb;
    private GameObject[] chairPoint;
    private GameObject[] seatingPlace;
    private int chairNumber = 0;

    private Vector3 velocity;
    public Vector3 worldVelocity;

    private Vector3 forward = new Vector3(0, 0, 1).normalized;    
    private Vector3 entry;

    private bool enteredRestaurant = false;
    private bool chairPassed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        chairPoint = GameObject.FindGameObjectsWithTag("ChairPoint");
        seatingPlace = GameObject.FindGameObjectsWithTag("SeatingPlace");
        entry = GameObject.Find("EntryPoint").transform.position;
        GetRandomPlace();
        //Debug.Log(chair0);
    }

    void FixedUpdate()
    {
        //int availableSeats = 0;
        //bool queue = false;
        if (!enteredRestaurant && Vector3.Distance(transform.position, entry) > 0.5f)
            MoveTo(entry);
        else
        {
            enteredRestaurant = true;
            //for (int i = 0; i < ChairManager.chairPassed.Length; i++)
            //    if (ChairManager.chairPassed[chairNumber] == false)
            //        availableSeats++;

            //if (availableSeats == 0)
            //    queue = true;
            //if (queue)
            //    Stop();
            if (/*!ChairManager.chairPassed[chairNumber] && */ !chairPassed && Vector3.Distance(transform.position, chairPoint[chairNumber].transform.position) > 0.5f)
                MoveTo(chairPoint[chairNumber].transform.position);
            else
            {
                Stop();
                if (chairNumber % 2 != 0)
                {
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                transform.position = seatingPlace[chairNumber].transform.position;
                //ChairManager.chairPassed[chairNumber] = true;
                chairPassed = true;
            }
        }
    }

    public void MoveTo(Vector3 destination)
    {
        Vector3 direction = destination - transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        velocity = forward * speed;
        velocity.y = rb.velocity.y;
        worldVelocity = transform.TransformVector(velocity);
        rb.velocity = worldVelocity;
    }
    
    public void Stop()
    {        
        velocity = forward * 0;
        velocity.y = rb.velocity.y;
        worldVelocity = transform.TransformVector(velocity);
        rb.velocity = worldVelocity;
    }

    public void GetRandomPlace()
    {
        chairNumber = UnityEngine.Random.Range(0, seatingPlace.Length);
        while (ChairManager.chairPassed[chairNumber] == true)
            chairNumber = UnityEngine.Random.Range(0, seatingPlace.Length);
        ChairManager.chairPassed[chairNumber] = true;
    }
}
