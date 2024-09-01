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

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + _lives.ToString();
        scoreText.text = "Score: " + _score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
