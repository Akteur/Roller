using TMPro;
using UnityEngine;

public class BestScoreCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = GameManager.Instance.BestScore.ToString();
    }
}
