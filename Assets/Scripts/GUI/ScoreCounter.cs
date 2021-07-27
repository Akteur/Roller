using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    TextMeshProUGUI score;
    private void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        UpdateScore();
    }
    void UpdateScore()
    {
        score.text = GameManager.Instance.Points.ToString();
    }
}
