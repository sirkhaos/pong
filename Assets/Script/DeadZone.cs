using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadZone : MonoBehaviour
{
    public Text scoreText;
    private int score;
    [SerializeField]
    private SceneChanger sc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Ball"))
        {
            score++;
            scoreText.text = score.ToString("D2");
            if (score >= 3)
            {
                if (tag.Equals("Right"))
                {
                    sc.ChangeSceneTo("WinScene");
                }
                else if (tag.Equals("Left"))
                    {
                        sc.ChangeSceneTo("GameOverScene");
                }
            }
            collision.GetComponent<BallController>().ballStop = true;
            collision.transform.position = Vector3.zero;
        }
    }
}
