using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [Header("Movement")]
    public float acceleration = 30f;
    public float maxSpeed = 20f;
    public float turnStrength = 120f;
    public float drag = 2f;

    [Header("Grip")]
    public float driftFactor = 0.95f;

    private Rigidbody rb;

    private float moveInput;
    private float turnInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
        rb.useGravity = true;
    }

    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Move();
        Turn();
        ApplyFriction();
        LimitSpeed();
        ReduceSidewaysSlip();
    }

    void Move()
    {
        rb.AddForce(transform.forward * moveInput * acceleration, ForceMode.Acceleration);
    }

    void Turn()
    {
        float speedFactor = Mathf.Clamp(rb.linearVelocity.magnitude / maxSpeed, 0.2f, 1f);
        float directionMultiplier = moveInput >= 0 ? 1f : -1f;

        float turn = turnInput * turnStrength * speedFactor * directionMultiplier * Time.fixedDeltaTime;

        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turn, 0f));
    }

    void ApplyFriction()
    {
        Vector3 vel = rb.linearVelocity;

        Vector3 flatVel = new Vector3(vel.x, 0, vel.z);
        flatVel *= (1f - drag * Time.fixedDeltaTime);

        rb.linearVelocity = new Vector3(flatVel.x, vel.y, flatVel.z);
    }

    void LimitSpeed()
    {
        Vector3 vel = rb.linearVelocity;
        Vector3 flatVel = new Vector3(vel.x, 0, vel.z);

        if (flatVel.magnitude > maxSpeed)
        {
            Vector3 limited = flatVel.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(limited.x, vel.y, limited.z);
        }
    }

    void ReduceSidewaysSlip()
    {
        Vector3 localVel = transform.InverseTransformDirection(rb.linearVelocity);
        localVel.x *= driftFactor;

        rb.linearVelocity = transform.TransformDirection(localVel);
    }
}