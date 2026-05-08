using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [Header("Car Settings")]
    public float moveSpeed = 15f;
    public float turnSpeed = 120f;
    public float brakeForce = 5f;

    private Rigidbody rb;

    private float moveInput;
    private float turnInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Better car stability
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
    }

    void Update()
    {
        // W/S or Up/Down
        moveInput = Input.GetAxis("Vertical");

        // A/D or Left/Right
        turnInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        MoveCar();
        TurnCar();
        ApplyBrake();
    }

    void MoveCar()
    {
        Vector3 moveDirection = transform.forward * moveInput * moveSpeed;

        rb.linearVelocity = new Vector3(
            moveDirection.x,
            rb.linearVelocity.y,
            moveDirection.z
        );
    }

    void TurnCar()
    {
        if (moveInput != 0)
        {
            float turn = turnInput * turnSpeed * Time.fixedDeltaTime;

            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }

    void ApplyBrake()
    {
        // Space key for brake
        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity *= (1 - brakeForce * Time.fixedDeltaTime);
        }
    }
}