using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestoyer : MonoBehaviour
{
    Transform mainCamera;
    Transform player;
    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Tilemap")
        {
            if (GameManager.Instance.DestroyTime)
            {
                Tilemap tilemap = collision.gameObject.GetComponent<Tilemap>();
                for (int i = 0; i < 5; i++)
                {
                    tilemap.SetTile(new Vector3Int((int)player.position.x - 1 + i, (int)mainCamera.position.y - 2, 0), null);
                }
            }
        }        
    }
}