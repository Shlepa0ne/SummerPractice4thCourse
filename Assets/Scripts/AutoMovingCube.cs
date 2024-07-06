using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class AutoMovingCube : MonoBehaviour
{
    public MovingVisitor movingVisitor;

    [SerializeField] private float speed = 13f;
    [SerializeField] private float turnSmoothTime = 0.06f;
    private float turnSmoothVelocity;

    private Rigidbody rb;

    public List<int> occupiedChairs = new List<int>();

    public Vector3 currentChairPoint;
    private Vector3 velocity;
    public Vector3 worldVelocity;
    private Vector3 forward = new Vector3(0, 0, 1).normalized;
    private Vector3 startPosition;
    private Vector3 kitchenPoint;

    public bool readyToOrder = false;
    public bool orderAccepted = false;
    public bool cameToKitchen = false;
    public bool burgerIsTaken = false;
    public bool putBurgerDown = false;
    public bool orderDone = false;
    private float distance;
    private int timer = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = GameObject.Find("StartPoint").transform.position;
        kitchenPoint = GameObject.Find("KitchenPoint").transform.position;
        //Debug.Log(startPosition);
        //Debug.Log(kitchenPoint);
    }

    void FixedUpdate()
    {
        movingVisitor = FindObjectOfType<MovingVisitor>();
        if (occupiedChairs.Count > 0)
        {
            currentChairPoint = ChairManager.chairPoint[occupiedChairs[0]].transform.position;
            distance = Vector3.Distance(transform.position, currentChairPoint);
            if (((readyToOrder && !orderAccepted) || burgerIsTaken) && distance > 0.5f)
                MoveTo(currentChairPoint);
            else if (distance < 0.5f)
            {
                Stop();
                if (occupiedChairs[0] < 4)
                    transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                else
                    transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                if (burgerIsTaken)
                {
                    putBurgerDown = true;
                }
                timer++;
                if (timer > 30)
                {
                    orderAccepted = true;
                    timer = 0;
                }
            }

            if (orderAccepted && !cameToKitchen && Vector3.Distance(transform.position, kitchenPoint) > 0.5)
                MoveTo(kitchenPoint);
            else if (orderAccepted && !burgerIsTaken)
            {
                cameToKitchen = true;
                Stop();
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if (orderDone)
            {
                readyToOrder = false;
                orderAccepted = false;
                cameToKitchen = false;
                burgerIsTaken = false;
                putBurgerDown = false;
                orderDone = false;
                occupiedChairs.Remove(0);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, startPosition) > 0.5f)
                MoveTo(startPosition);
            else
            {
                Stop();
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
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
