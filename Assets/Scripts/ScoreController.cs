using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text playerOneScoreValue;
    [SerializeField] private TMP_Text playerTwoScoreValue;
    [SerializeField] private TMP_Text playerThreeScoreValue;
    [SerializeField] private TMP_Text playerFourScoreValue;
    [SerializeField] private ScoreManager manager;

    private void Update()
    {
        playerOneScoreValue.SetText(manager.playerOneScore.ToString());
        playerTwoScoreValue.SetText(manager.playerTwoScore.ToString());
        playerThreeScoreValue.SetText(manager.playerThreeScore.ToString());
        playerFourScoreValue.SetText(manager.playerFourScore.ToString());
    }
}
