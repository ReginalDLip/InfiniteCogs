using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 8f;
    public float jumpForce = 22f;

    [Header("Audio")]
    public AudioClip jumpSound; // Slot suara loncat
    public AudioClip landSound; // Slot suara mendarat (BARU)
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
        
        // PENTING: Gunakan 'velocity' jika Unity versi lama, 'linearVelocity' untuk Unity 6
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        // Input Loncat
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Membalik arah sprite
        if (moveX > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveX < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.linearVelocity = Vector2.up * jumpForce;
        isGrounded = false;

        // Mainkan Suara Loncat
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
                // Jika normal.y > 0.5f artinya kita menabrak bagian ATAS (mendarat), bukan samping/bawah
                if (contact.normal.y > 0.5f)
                {
                    isGrounded = true;

                    // --- LOGIKA SUARA MENDARAT ---
                    // Syarat:
                    // 1. Ada file suaranya
                    // 2. AudioSource ada
                    // 3. Nama objeknya BUKAN "StartGround" (Lantai paling bawah)
                    if (landSound != null && audioSource != null && collision.gameObject.name != "StartGround")
                    {
                        // Ubah volume sedikit lebih kecil (0.5f) biar tidak berisik, atau hapus ", 0.5f" jika ingin keras
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