using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Mencegah terjadinya bug ketika Bola terlock mantul tembok atas bawah

    public void ResetButton()
    {
        Debug.Log("Reset");
        scoreManager.ResetGame();
    }
}
