using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text highScoreText;

    void Start()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = highScore.ToString("F2") + " m";
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); 
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Keluar Game");
    }
}