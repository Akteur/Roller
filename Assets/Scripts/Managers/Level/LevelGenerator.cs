using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] public TileBase wallPink;
    [SerializeField] public TileBase sizeReducer;
    [SerializeField] public TileBase wallDestroyer;
    Tilemap tilemap;
    Tilemap tilemapSizeReduce;
    Tilemap tilemapDestroyWalls;
    int y = 5;
    int emptyTile = 3;
    int newEmptyTile = 3;
    int dirChangedLayer;
    int layer;
    void Start()
    {
        GameManager.Instance.gameStarted = true;
        tilemap = LevelManager.tilemap;
        tilemapSizeReduce = LevelManager.tilemapReduceSize;
        tilemapDestroyWalls = LevelManager.tilemapDestroyWalls;
    }

    void FixedUpdate()
    {
        if(LevelManager.layerCount < 100)
        {
            if (layer % 4 == 0 && layer != 0)
            {
                emptyTile = newEmptyTile;
                dirChangedLayer = layer;
                newEmptyTile = GenerateRandomDirection(emptyTile);
            }
            GenerateNewLayer(y++, emptyTile, newEmptyTile);
        }
    }
    private void GenerateNewLayer(int y, int emptyTile, int newEmptyTile)
    {
        for (int i = 0; i < 7; i++)
        {
            if (y-5 == dirChangedLayer || y-5 == dirChangedLayer+1)
            {
                if (i == newEmptyTile || i == emptyTile)
                {                    
                    continue;
                }
                else
                {
                    GenerateTile(i - 3, y, wallPink);
                }
            }
            else
            {
                if (i != newEmptyTile)
                {
                    GenerateTile(i - 3, y, wallPink);
                }
            }
            GenerateSizeReducer(newEmptyTile - 3, y, sizeReducer);
            GenerateTileDestroyer(newEmptyTile - 3, y, wallDestroyer);
        }
        LevelManager.layerCount++;
        layer++;
    }
    private void GenerateTile(int x, int y, TileBase tile)
    {        
        tilemap.SetTile(new Vector3Int(x, y, 0), tile);   
    }
    private int GenerateRandomDirection(int emptyTile)
    {
        int result = emptyTile;
        int randomDir = Random.Range(0, 10);        
        if(randomDir < 5)
        {
            result--;            
        }
        else
        {
            result++;
        }
        if (result < 2)
        {
            result = 2;
        }
        else if (result > 5)
        {
            result = 5;
        }
        Random.InitState((int)System.DateTime.Now.Ticks);
        return result;
    }

    private void GenerateSizeReducer(int x, int y, TileBase tile)
    {
        if(layer % 30 == 0 && layer != 0)
        {
            tilemapSizeReduce.SetTile(new Vector3Int(x, y, 0), tile);
        }
    }
    private void GenerateTileDestroyer(int x, int y, TileBase tile)
    {
        if (layer % 100 == 0 && layer != 0)
        {
            tilemapDestroyWalls.SetTile(new Vector3Int(x, y, 0), tile);
        }
    }
}
