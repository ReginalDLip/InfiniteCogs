using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathFloor : MonoBehaviour
{
    [Header("Settings")]
    public float riseSpeed = 1.0f; 
    public Transform player;   
    void Update()
    {
        transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
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

            if(currentScore > oldHighScore)
            {
                PlayerPrefs.SetFloat("HighScore", currentScore);
                PlayerPrefs.Save();
            }
        }
    }
}