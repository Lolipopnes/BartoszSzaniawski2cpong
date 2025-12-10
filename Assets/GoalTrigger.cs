using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public bool isLeftGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            GameManager gm = FindObjectOfType<GameManager>();

            if (isLeftGoal)
                gm.AddPlayer2Score(); 
            else
                gm.AddPlayer1Score(); 

            collision.GetComponent<Ball>().ResetBall();
        }
    } 
}