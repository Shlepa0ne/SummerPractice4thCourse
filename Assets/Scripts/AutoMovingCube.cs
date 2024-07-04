using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovingCube : MonoBehaviour
{
    public MovingVisitor movingVisitor;

    [SerializeField] private float speed = 13f;
    [SerializeField] private float turnSmoothTime = 0.06f;
    private float turnSmoothVelocity;
    private Rigidbody rb;

    public List<int> occupiedChairs = new List<int>();

    private Vector3 velocity;
    public Vector3 worldVelocity;
    private Vector3 forward = new Vector3(0, 0, 1).normalized;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = GameObject.Find("StartPoint").transform.position;        
    }

    void FixedUpdate()
    {
        movingVisitor = FindObjectOfType<MovingVisitor>();
        if (occupiedChairs.Count > 0)
            MoveTo(ChairManager.chairPoint[occupiedChairs[0]].transform.position);
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
}
