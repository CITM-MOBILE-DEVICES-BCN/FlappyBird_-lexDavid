using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TextMeshProUGUI scoreText;
    public static ScoreUI instance;
    private int score;

    private void Awake()
    {
       if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
