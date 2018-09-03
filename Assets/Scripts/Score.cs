using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text score;
    static public string scoreForFinish;
    private int curScore = 0;
    private int bufferScore = 0;
    private Boolean onRail = false;

    private void Start()
    {
        scoreForFinish = "0";
    }
    void Update() {
        if (onRail)
        {
            bufferScore += 5;
            UpdateScoreText();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Rail")
        {
            onRail = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        onRail = false;
    }

    public void KickFlip(int speed)
    {
        bufferScore += 25 * speed;
        UpdateScoreText();
    }

    public void TrickLanded(Boolean landed)
    {
        if (landed)
        {
            curScore += bufferScore;
            scoreForFinish = curScore.ToString();
        }
        bufferScore = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        score.text = bufferScore > 0 ?
            curScore.ToString() + "+" + bufferScore.ToString() : curScore.ToString();
    }
}
