using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_Move : MonoBehaviour
{
    [SerializeField] private float speed = 13f;
    [SerializeField] private float turnSmoothTime = 0.07f;
    private float turnSmoothVelocity;
    private Rigidbody rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, 0f, v).normalized;
        Vector3 forward = new Vector3(0, 0, 1).normalized;

        if (direction.magnitude >= 0.1f)
        {            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle-11.25f, 0f);

            Vector3 velocity = forward * speed;
            velocity.y = rb.velocity.y;
            Vector3 worldVelocity = transform.TransformVector(velocity);
            rb.velocity = worldVelocity;
        }
        else
        {
            Vector3 velocity = forward * 0;
            velocity.y = rb.velocity.y;
            Vector3 worldVelocity = transform.TransformVector(velocity);
            rb.velocity = worldVelocity;
        }

        animator.SetBool("cubeMoving", direction.magnitude >= 0.1f);
    }
}