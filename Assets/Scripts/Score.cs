using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text score;
    private int curScore = 0;
    private int bufferScore = 0;
    private Boolean onRail = false;

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
