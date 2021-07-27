using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsActivation : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.ReduceSize = false;
        GameManager.Instance.DestroyTime = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "TilemapReduceSize")
        {
            GameManager.Instance.ReduceSize = true;
            StartCoroutine(WallDestroyerDeactivation());
        }
        if(collision.gameObject.name == "TilemapDestroyTiles")
        {
            GameManager.Instance.DestroyTime = true;
            StartCoroutine(SizeReducerDeactivation());
        }
        collision = null;
    }

    IEnumerator WallDestroyerDeactivation()
    {
        yield return new WaitForSeconds(5f);
        GameManager.Instance.DestroyTime = false;        
    }
    IEnumerator SizeReducerDeactivation()
    {
        yield return new WaitForSeconds(3f);
        GameManager.Instance.ReduceSize = false;     
    }
}
