using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathFloor : MonoBehaviour
{
    [Header("Settings")]
    public float riseSpeed = 1.0f; // Kecepatan naik lava
    public Transform player;       // Drag Player ke sini untuk cek skor

    void Update()
    {
        // --- INI KODE AGAR LAVA NAIK TERUS ---
        // Bergerak ke arah ATAS (Vector3.up) dikali Kecepatan dikali Waktu
        transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Jika menyentuh Player -> Game Over
        if (other.CompareTag("Player"))
        {
            SaveHighScore();
            SceneManager.LoadScene("MainMenu");
        }
    }

    void SaveHighScore()
    {
        if (player != null)
        {
            float currentScore = player.position.y;
            float oldHighScore = PlayerPrefs.GetFloat("HighScore", 0);

            if (currentScore > oldHighScore)
            {
                PlayerPrefs.SetFloat("HighScore", currentScore);
                PlayerPrefs.Save();
            }
        }
    }
}