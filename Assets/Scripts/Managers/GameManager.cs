using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    GameObject player;
    public bool gameStarted;
    public bool DestroyTime { get; set; }
    public bool ReduceSize { get; set; }
    public int Points { get; set; }
    public int BestScore { get; set; }
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(Instance);
    }

    private void Start()
    {
        DestroyTime = false;
        ReduceSize = false;
        Points = 0;
        BestScore = 0;
        player = GameObject.Find("Main Camera");
    }
    private void Update()
    {
        if(player == null)
        {
            player = GameObject.Find("Main Camera");
        }
        if (gameStarted)
        {
            pointsCounter(player.transform.position.y);
        }
    }
    private void pointsCounter(float distance)
    {
        Points = (int)distance / 2;
    }
}
