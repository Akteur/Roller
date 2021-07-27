using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelDestroyer : MonoBehaviour
{
    Tilemap tilemap;
    int layer = -7;
    bool coroutineStarted;
    bool coroutinePerformed;
    private void Start()
    {
        tilemap = LevelManager.tilemap;
    }
    void FixedUpdate()
    {
        if(LevelManager.layerCount > 50)
        {
            if (!coroutineStarted)
            {
                StartCoroutine(RemoveTiles());
                coroutineStarted = true;
            }
            else if (coroutinePerformed)
            {
                StopCoroutine(RemoveTiles());
                coroutineStarted = false;
            }
        }
    }

    IEnumerator RemoveTiles()
    {
        coroutinePerformed = false;
        yield return new WaitForSeconds(0.2f);
        layer++;
        for(int i = 0; i < 7; i++)
        {
            tilemap.SetTile(new Vector3Int(i-3, layer, 0), null);
        }
        LevelManager.layerCount--;
        coroutinePerformed = true;
    }
}
