using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private TMP_Text winnerLabel;

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Replay()
    {
        Debug.Log("Replay");
        scoreManager.ResetGame();
    }

    public void ShowWinner(string player)
    {
        player = player.Insert(6, " ");
        winnerLabel.SetText(player + " Win!!!");
    }
}
