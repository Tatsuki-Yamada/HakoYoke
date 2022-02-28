using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text gameOverText;
    [SerializeField] Text pressQText;


    private void Start()
    {
        gameOverText.enabled = false;
        pressQText.enabled = false;
    }


    private void Update()
    {
        scoreText.text = "Score : " + GameManager.Instance.score;

        if (!GameManager.Instance.inGame)
        {
            gameOverText.enabled = true;
            pressQText.enabled = true;
        }
    }


    public void Amazing()
    {
        gameOverText.text = "Amazing !!!!";
        gameOverText.enabled = true;
        pressQText.enabled = true;
    }
}