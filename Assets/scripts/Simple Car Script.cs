using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleCarController : MonoBehaviour
{
    public float speed = 15f;
    public float turnSpeed = 100f;

    private Rigidbody rb;
    private float moveInput;
    private float turnInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Input
        moveInput = Input.GetAxis("Vertical");   // W/S
        turnInput = Input.GetAxis("Horizontal"); // A/D
    }

    void FixedUpdate()
    {
        // Move forward/backward
        Vector3 move = transform.forward * moveInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        // Turn left/right
        float turn = turnInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}