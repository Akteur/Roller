using UnityEngine;

public class Controll : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    public void MoveLeft()
    {
        player.transform.position = new Vector3(player.transform.position.x - 1, player.transform.position.y, 0);
    }
    public void MoveRight()
    {
        player.transform.position = new Vector3(player.transform.position.x + 1, player.transform.position.y, 0);
    }
}
