/*****************************************************************************
// File Name : EndMenu.cs
// Author : Kaden Stigter
// Creation Date : September 1, 2024
//
// Brief Description : 
*****************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    /// <summary>
    /// restarts the game when the restart button is pressed
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// quits the game when the quit button is pressed
    /// </summary>
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
