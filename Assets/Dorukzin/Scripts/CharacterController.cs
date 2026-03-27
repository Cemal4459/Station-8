using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    [Header("References")]
    public CharacterController controller;

    private Vector3 velocity;
    private bool isGrounded;

    void Update()
    {
        // Zeminde mi kontrolü
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Inputlar
        float x = Input.GetAxis("Horizontal"); // A/D
        float z = Input.GetAxis("Vertical");   // W/S

        // Hýz seçimi (Shift ile yavaþ)
        float speed = Input.GetKey(KeyCode.LeftShift) ? walkSpeed : runSpeed;

        // Hareket yönü (karakterin baktýðý yöne göre)
        Vector3 move = transform.right * x + transform.forward * z;

        // Hareket ettirme
        controller.Move(move * speed * Time.deltaTime);

        // Zýplama
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Yerçekimi
        velocity.y += gravity * Time.deltaTime;

        // Dikey hareket
        controller.Move(velocity * Time.deltaTime);
    }
}