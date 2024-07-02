using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingVisitor : MonoBehaviour
{
    [SerializeField] private float speed = 13f;
    [SerializeField] private float turnSmoothTime = 0.06f;
    private float turnSmoothVelocity;

    private Rigidbody rb;
    private int chairNumber = 0;

    private Vector3 velocity;
    public Vector3 worldVelocity;

    private Vector3 forward = new Vector3(0, 0, 1).normalized;    
    private Vector3 entry;

    private bool queueFlag = false;
    private bool inQueue = false;
    private bool enteredRestaurant = false;
    private bool checkedQueue = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        entry = GameObject.Find("EntryPoint").transform.position;
        GetRandomPlace();        
        //Debug.Log(entry);
    }

    void FixedUpdate()
    {
        int numberInQueue = 0;
        Vector3 queuePosition = new Vector3(0, 0, 0).normalized;

        if (chairNumber < 0)
        {
            if (!queueFlag)
            {
                ChairManager.queueLength += 1;
                numberInQueue = ChairManager.queueLength;
                queueFlag = true;
            }
                        
            queuePosition = entry + new Vector3(0f, 0f, numberInQueue * 2f);
            if (!inQueue && Vector3.Distance(transform.position, queuePosition) > 0.5f)
                MoveTo(queuePosition);
            else
            {
                inQueue = true;
                Stop();
            }
        }

        else if (!enteredRestaurant && Vector3.Distance(transform.position, entry) > 0.5f)
            MoveTo(entry);
        else
        {
            enteredRestaurant = true;            
            if (!ChairManager.chairPassed[chairNumber] && Vector3.Distance(transform.position, ChairManager.chairPoint[chairNumber].transform.position) > 0.5f)
                MoveTo(ChairManager.chairPoint[chairNumber].transform.position);
            else
            {
                Stop();
                if (chairNumber % 2 != 0)
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                else
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                transform.position = ChairManager.seatingPlace[chairNumber].transform.position;
                ChairManager.chairPassed[chairNumber] = true;
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

    private void GetRandomPlace()
    {
        List<int> availableChairs = new List<int>();
        for (int i = 0; i < ChairManager.chairPassed.Length; i++)
            if (!ChairManager.chairPassed[i])
                availableChairs.Add(i);

        if (availableChairs.Count > 0)
            chairNumber = availableChairs[UnityEngine.Random.Range(0, availableChairs.Count)];
        else
            chairNumber = -1;
    }
    
    public int ChairNumber
    {
        get { return chairNumber; }
    }
}
