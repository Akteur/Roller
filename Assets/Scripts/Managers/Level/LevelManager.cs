using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    public static Tilemap tilemap;
    public static Tilemap tilemapReduceSize;
    public static Tilemap tilemapDestroyWalls;
    public static int layerCount = 0;
    void Awake()
    {
        layerCount = 0;
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        tilemapReduceSize = GameObject.Find("TilemapReduceSize").GetComponent<Tilemap>();
        tilemapDestroyWalls = GameObject.Find("TilemapDestroyTiles").GetComponent<Tilemap>();
    }
}
