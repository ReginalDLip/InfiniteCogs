using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text highScoreText;

    void Start()
    {
        // Ambil data High Score dari memori. Jika belum ada, defaultnya 0.
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = highScore.ToString("F2") + " m";
    }

    public void PlayGame()
    {
        // Pastikan nama scene di dalam kutip SAMA PERSIS dengan nama file scene game Anda
        SceneManager.LoadScene("GameScene"); 
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Keluar Game");
    }
}