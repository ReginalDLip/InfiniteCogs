using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 8f;
    public float jumpForce = 22f;

    [Header("Audio")]
    public AudioClip jumpSound;
    public AudioClip landSound;
    private AudioSource audioSource;

    private Rigidbody2D rb;
    private float moveX;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        if (moveX > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveX < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.linearVelocity = Vector2.up * jumpForce;
        isGrounded = false;
        if (jumpSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            // Cek titik kontak tabrakan
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    isGrounded = true;
                    if (landSound != null && audioSource != null && collision.gameObject.name != "StartGround")
                    {
                        audioSource.PlayOneShot(landSound, 0.6f); 
                    }
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }
}