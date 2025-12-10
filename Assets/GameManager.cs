using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Score Settings")]
    public int player1Score = 0;
    public int player2Score = 0;
    public int winScore = 5; 

    [Header("UI References")]
    public TMP_Text Player1ScoreText;
    public TMP_Text Player2ScoreText;
    public GameObject winScreen;
    public TMP_Text winText;
    public Image winFlashImage; 

    private bool gameOver = false;

    void Start()
    {
        UpdateScoreUI();
    }

    void Update()
    {
        
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void AddPlayer1Score()
    {
        if (gameOver) return;
        player1Score++;
        UpdateScoreUI();
        CheckWin();
    }

    public void AddPlayer2Score()
    {
        if (gameOver) return;
        player2Score++;
        UpdateScoreUI();
        CheckWin();
    }

    void UpdateScoreUI()
    {
        Player1ScoreText.text = player1Score.ToString();
        Player2ScoreText.text = player2Score.ToString();
    }

    void CheckWin()
    {
        if (player1Score >= winScore)
        {
            ShowWinScreen("Player 1 Wins! Congratulations!");
        }
        else if (player2Score >= winScore)
        {
            ShowWinScreen("Player 2 Wins! Well done!");
        }
    }

    void ShowWinScreen(string message)
    {
        gameOver = true;
        winScreen.SetActive(true);
        winText.text = message;
        Time.timeScale = 0f; 

        
        if (winFlashImage != null)
        {
            StartCoroutine(FlashWinImage());
        }
    }

        private IEnumerator FlashWinImage()
    {
       
        winFlashImage.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
         winFlashImage.gameObject.SetActive(false);
    }



    public void RestartGame()
    {
        Time.timeScale = 1f;
        player1Score = 0;
        player2Score = 0;
        UpdateScoreUI();
        winScreen.SetActive(false);
        gameOver = false;
    }
}
