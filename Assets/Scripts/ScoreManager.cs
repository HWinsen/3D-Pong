using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int playerOneScore;
    public int playerTwoScore;
    public int playerThreeScore;
    public int playerFourScore;

    private int deadPlayerCount = 0;

    [SerializeField] private int maxScore;
    [SerializeField] private GameObject[] ball;

    [SerializeField] private GameObject playerOnePaddle;
    [SerializeField] private GameObject playerTwoPaddle;
    [SerializeField] private GameObject playerThreePaddle;
    [SerializeField] private GameObject playerFourPaddle;

    [SerializeField] private BoxCollider gawangPlayerOne;
    [SerializeField] private BoxCollider gawangPlayerTwo;
    [SerializeField] private BoxCollider gawangPlayerThree;
    [SerializeField] private BoxCollider gawangPlayerFour;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject objectPooler;
    [SerializeField] private GameObject ballSpawner;

    public void AddPlayerOneScore(int increment)
    {
        playerOneScore += increment;

        if (playerOneScore >= maxScore)
        {
            deadPlayerCount += 1;
            playerOnePaddle.SetActive(false);
            gawangPlayerOne.isTrigger = false;
            GameOver();
        }
    }

    public void AddPlayerTwoScore(int increment)
    {
        playerTwoScore += increment;

        if (playerTwoScore >= maxScore)
        {
            deadPlayerCount += 1;
            playerTwoPaddle.SetActive(false);
            gawangPlayerTwo.isTrigger = false;
            GameOver();
        }
    }

    public void AddPlayerThreeScore(int increment)
    {
        playerThreeScore += increment;

        if (playerThreeScore >= maxScore)
        {
            deadPlayerCount += 1;
            playerThreePaddle.SetActive(false);
            gawangPlayerThree.isTrigger = false;
            GameOver();
        }
    }

    public void AddPlayerFourScore(int increment)
    {
        playerFourScore += increment;
        //ResetGame();

        if (playerFourScore >= maxScore)
        {
            deadPlayerCount += 1;
            playerFourPaddle.SetActive(false);
            gawangPlayerFour.isTrigger = false;
            GameOver();
        }
    }

    public void GameOver()
    {
        if (deadPlayerCount < 3)
        {
            return;
        }
        else
        {
            ballSpawner.SetActive(false);
            objectPooler.SetActive(false);
            ball = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject obj in ball)
            {
                obj.SetActive(false);
            }
            gameOverCanvas.SetActive(true);

            if (playerOneScore < maxScore)
            {
                gameOverCanvas.GetComponent<GameOverController>().ShowWinner(playerOnePaddle.tag);
            }
            else if (playerTwoScore < maxScore)
            {
                gameOverCanvas.GetComponent<GameOverController>().ShowWinner(playerTwoPaddle.tag);
            }
            else if (playerThreeScore < maxScore)
            {
                gameOverCanvas.GetComponent<GameOverController>().ShowWinner(playerThreePaddle.tag);
            }
            else if (playerFourScore < maxScore)
            {
                gameOverCanvas.GetComponent<GameOverController>().ShowWinner(playerFourPaddle.tag);
            }
        }
    }

    public void ResetGame()
    {
        objectPooler.SetActive(true);
        ballSpawner.SetActive(true);

        deadPlayerCount = 0;
        playerOneScore = 0;
        playerTwoScore = 0;
        playerThreeScore = 0;
        playerFourScore = 0;

        gawangPlayerOne.isTrigger = true;
        gawangPlayerTwo.isTrigger = true;
        gawangPlayerThree.isTrigger = true;
        gawangPlayerFour.isTrigger = true;
        
        playerOnePaddle.GetComponent<PaddleController>().ResetPaddle();
        playerTwoPaddle.GetComponent<PaddleController>().ResetPaddle();
        playerThreePaddle.GetComponent<PaddleController>().ResetPaddle();
        playerFourPaddle.GetComponent<PaddleController>().ResetPaddle();
        
        playerOnePaddle.SetActive(true);
        playerTwoPaddle.SetActive(true);
        playerThreePaddle.SetActive(true);
        playerFourPaddle.SetActive(true);

        gameOverCanvas.SetActive(false);
    }
}
