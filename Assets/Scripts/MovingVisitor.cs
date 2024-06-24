using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingVisitor : MonoBehaviour
{
    [SerializeField] private float speed = 13f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private Rigidbody rb;

    private Vector3 velocity;
    public Vector3 worldVelocity;

    private Vector3 forward = new Vector3(0, 0, 1).normalized;
    private Vector3 entry = new Vector3(1f, 0.5f, -6.75f);
    private Vector3 chair1 = new Vector3(4.25f, 0.5f, -6.75f);
    private Vector3 chair2 = new Vector3(4.25f, 0.5f, 2.5f);

    private bool enteredRestaurant = false;
    private bool chair1Passed = false;
    private bool chair2Passed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!enteredRestaurant && Vector3.Distance(GetComponent<Transform>().position, entry) > 0.5f)
            MoveTo(entry);
        else
        {
            enteredRestaurant = true;
            //Stop();
            if (!chair1Passed && Vector3.Distance(GetComponent<Transform>().position, chair1) > 0.5f)
                MoveTo(chair1);
            else
            {
                chair1Passed = true;
                //Stop();
                if (chair1Passed && !chair2Passed && Vector3.Distance(GetComponent<Transform>().position, chair2) > 0.5f)
                    MoveTo(chair2);
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
        Vector3 direction = destination - GetComponent<Transform>().position;
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
