using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    void Update()
    {
        if (GameManager.Instance != null)
        {
            scoreText.text = "SCORE: " + GameManager.Instance.score;
            livesText.text = "LIVES: " + GameManager.Instance.lives;
        }
    }
}