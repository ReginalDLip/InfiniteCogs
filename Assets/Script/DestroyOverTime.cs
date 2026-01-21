using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    private Transform player;
    private float destroyDistance = 50f; // Jarak aman penghapusan

    void Start()
    {
        // Cari player otomatis
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            // Jika posisi objek ini jauh di bawah player
            if (transform.position.y < player.position.y - destroyDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}