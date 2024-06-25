using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingVisitor : MonoBehaviour
{
    [SerializeField] private float speed = 13f;
    [SerializeField] private float turnSmoothTime = 0.06f;
    private float turnSmoothVelocity;

    private Rigidbody rb;
    private ArrayOfPoints point;

    private Vector3 velocity;
    public Vector3 worldVelocity;

    private Vector3 forward = new Vector3(0, 0, 1).normalized;    
    private Vector3 entry;
    private Vector3 chair0;
    private Vector3 chair1;

    private bool enteredRestaurant = false;
    private bool chair1Passed = false;
    private bool chair2Passed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        point = GetComponent<ArrayOfPoints>();
        entry = GameObject.Find("EntryPoint").transform.position;
        chair0 = point.chair[0].transform.position;
        //Debug.Log(chair0);
    }

    void FixedUpdate()
    {
        if (!enteredRestaurant && Vector3.Distance(transform.position, entry) > 0.5f)
            MoveTo(entry);
        else
        {
            enteredRestaurant = true;
            if (!chair1Passed && Vector3.Distance(transform.position, chair0) > 0.5f)
                MoveTo(chair0);
            else
            {
                chair1Passed = true;
                if (chair1Passed && !chair2Passed && Vector3.Distance(transform.position, point.chair[3].transform.position) > 0.5f)
                    MoveTo(point.chair[3].transform.position);
                else
                {
                    chair2Passed = true;
                    Stop();
                }
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
}
