using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 100;
    void Start()
    {
        speed = speed / 100;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        MoveUp();
        speed += 0.00002f;
    }
    void MoveUp()
    {
        transform.position += transform.up * speed;
    }
}
