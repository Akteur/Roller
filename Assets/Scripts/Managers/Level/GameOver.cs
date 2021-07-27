using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameManager.Instance.DestroyTime)
        {
            if(collision.transform.tag == "Player")
            {
                BestScoreUpdate();
                GameManager.Instance.gameStarted = false;
                SceneManager.LoadScene("GameOver");
            }
        }
    }
    void BestScoreUpdate()
    {
        if(GameManager.Instance.Points > GameManager.Instance.BestScore)
        {
            GameManager.Instance.BestScore = GameManager.Instance.Points;
        }
    }
}
