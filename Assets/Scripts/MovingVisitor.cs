using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingVisitor : MonoBehaviour
{
    [SerializeField] private float speed = 13f;
    [SerializeField] private float turnSmoothTime = 0.07f;
    private float turnSmoothVelocity;
    private Rigidbody rb;

    private Vector3 forward = new Vector3(0, 0, 1).normalized;
    private Vector3 entry = new Vector3(1f, 0.5f, -6f);

    private class tableStatus
    {
        public bool taken = false;
        public float X;
        public float Z;
    } 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Booked Table0 = new();
        //Booked Table1 = new();
        //Booked Table2 = new();
        //Booked Table3 = new();
        //Booked Table4 = new();
        //Booked Table5 = new();

        //Table0.taken = false;
        //Table1.taken = false;
        //Table2.taken = false;
        //Table3.taken = false;
        //Table4.taken = false;
        //Table5.taken = false;
    }

    void FixedUpdate()
    {
        if (GetComponent<Transform>().position != entry)
        {
            moveTo(entry);
        }
    }

    public void moveTo(Vector3 destination)
    {
        Vector3 direction = destination - GetComponent<Transform>().position;
        Vector3 velocity;
        Vector3 worldVelocity;

        if (GetComponent<Transform>().position != entry)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            velocity = forward * speed;
        }
        else
            velocity = forward * 0;
        velocity.y = rb.velocity.y;
        worldVelocity = transform.TransformVector(velocity);
        rb.velocity = worldVelocity;
    }
}
