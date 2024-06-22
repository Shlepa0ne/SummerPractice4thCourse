using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    [SerializeField] private float speed = 13f;
    [SerializeField] private float turnSmoothTime = 0.07f;
    private float turnSmoothVelocity;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, 0f, v).normalized;
        Vector3 forward = new Vector3(0, 0, 1).normalized;
        Vector3 velocity;

        if (direction.magnitude >= 0.1f)
        {
            Animation.moving = true;
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle-11.25f, 0f);

            velocity = forward * speed;
        }
        else
        {
            Animation.moving = false;
            velocity = forward * 0;            
        }
        velocity.y = rb.velocity.y;
        Vector3 worldVelocity = transform.TransformVector(velocity);
        rb.velocity = worldVelocity;
    }
}