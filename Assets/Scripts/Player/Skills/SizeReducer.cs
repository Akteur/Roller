using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeReducer : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (GameManager.Instance.ReduceSize)
        {
            player.transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }
        else
        {
            player.transform.localScale = new Vector3(3, 3, 1);
        }
    }
}
