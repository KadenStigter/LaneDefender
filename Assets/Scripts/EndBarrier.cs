/*****************************************************************************
// File Name : EndBarrier.cs
// Author : Kaden Stigter
// Creation Date : September 1, 2024
//
// Brief Description : What happens when an enemy collides with the end of the screen
*****************************************************************************/

using TMPro;
using UnityEngine;

public class EndBarrier : MonoBehaviour
{
   private GameController gameController;
    public int _lives = 3;
    public TMP_Text livesText;
    [SerializeField] private GameObject _hud;
    [SerializeField] private GameObject _endScreen;

    /// <summary>
    /// start is called in the first frame update
    /// </summary>
    private void Start()
    {
        livesText.text = "Lives: " + _lives.ToString();
        _hud.SetActive(true);
        _endScreen.SetActive(false);
    }

    /// <summary>
    /// what happens when the enemies hit the end barrier
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _lives -= 1;
            livesText.text = "Lives: " + _lives.ToString();

            if (_lives == 0)
            {
                Time.timeScale = 0;
                _hud.SetActive(false);
                _endScreen.SetActive(true);
            }
        }
    }
}
