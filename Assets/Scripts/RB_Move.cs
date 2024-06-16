using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_Move : MonoBehaviour
{
    [SerializeField] private Rigidbody  rigidbody;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        
        //if (direction.magnitude >= 0.1f)
        //{
        //    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
        //    transform.rotation = Quaternion.Euler(0, angle, 0);

        //    Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        //    Vector3 velocity = moveDirection * speed;
        //    velocity.y = rigidbody.velocity.y;
        //    rigidbody.velocity = velocity;
        //}



        //if (direction.magnitude >= 0.1f)
        //{
        //    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            
        //}

        Vector3 direction = new Vector3(h, 0, v).normalized;

        float angle = 0;
        transform.rotation = Quaternion.Euler(0, angle, 0);
        Vector3 velocity = direction * speed;
        velocity.y = rigidbody.velocity.y;
        Vector3 worldVelocity = transform.TransformVector(velocity);
        rigidbody.velocity = worldVelocity;
    }
}
