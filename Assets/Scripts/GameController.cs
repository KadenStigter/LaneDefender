/*****************************************************************************
// File Name : GameController.cs
// Author : Kaden Stigter
// Creation Date : September 1, 2024
//
// Brief Description : Controls most of the game's functions, such as lives and score
*****************************************************************************/

using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text highScoreText;
    [SerializeField] private int _score = 0;
    public int _lives = 3;
    [SerializeField] private GameObject _hud;
    [SerializeField] private GameObject _endScreen;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        livesText.text = "Lives: " + _lives.ToString();
        scoreText.text = "Score: " + _score.ToString();
        HighScoreTextUpdate();
        _hud.SetActive(true);
        _endScreen.SetActive(false);
    }

    /// <summary>
    /// updates the score when enemy is killed
    /// </summary>
    public void UpdateScore()
    {
        _score += 100;
        scoreText.text = "Score: " + _score.ToString();

        //saves a high score in computer
        PlayerPrefs.SetInt("HighScore", _score);
        PlayerPrefs.GetInt("HighScore");
    }

    /// <summary>
    /// checks to see if the player has a new high score
    /// </summary>
    private void CheckHighScore()
    {
        if(_score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            HighScoreTextUpdate(); // dynamically updates high score in game
        }
    }

    /// <summary>
    /// what happens when a player loses a life
    /// </summary>
    public void LoseALife()
    {
        _lives -= 1;
        livesText.text = "Lives: " + _lives.ToString();

        if(_lives == 0)
        {
            Time.timeScale = 0;
            _hud.SetActive(false);
            _endScreen.SetActive(true);
        }
    }

    /// <summary>
    /// updates the high score during the game
    /// </summary>
    private void HighScoreTextUpdate()
    {
        highScoreText.text = $"High Score:  {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
