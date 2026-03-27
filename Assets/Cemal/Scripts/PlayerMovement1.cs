using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public CharacterController controller;

    [Header("Movement")]
    public float walkSpeed = 7.2f;

    [Header("Jump")]
    public float jumpHeight = 1.15f;
    public float gravity = -22f;
    public float fallMultiplier = 2.2f;
    public float lowJumpMultiplier = 1.8f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.3f;

    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        if (controller == null)
            controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Zemin kontrolü
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance);

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        // Hareket
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * walkSpeed * Time.deltaTime);

        // Zıplama
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Daha gerçekçi jump physics
        if (velocity.y < 0f)
        {
            velocity.y += gravity * fallMultiplier * Time.deltaTime;
        }
        else if (velocity.y > 0f && !Input.GetButton("Jump"))
        {
            velocity.y += gravity * lowJumpMultiplier * Time.deltaTime;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
    }
}