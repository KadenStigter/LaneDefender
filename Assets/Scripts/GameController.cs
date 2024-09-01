/*****************************************************************************
// File Name : GameController.cs
// Author : Kaden Stigter
// Creation Date : September 1, 2024
//
// Brief Description : Controls most of the game's functions, such as lives and score
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text livesText;
    [SerializeField] private int _score = 0;
    [SerializeField] private int _lives = 3;
    [SerializeField] private GameObject _hud;
    [SerializeField] private GameObject _endScreen;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + _lives.ToString();
        scoreText.text = "Score: " + _score.ToString();
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
    }

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
