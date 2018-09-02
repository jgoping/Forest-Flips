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
            score.text = curScore.ToString() + "+" + bufferScore.ToString();
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

    public void KickFlip()
    {
        bufferScore += 50;
        score.text = curScore.ToString() + "+" + bufferScore.ToString();
    }

    public void TrickLanded(Boolean landed)
    {
        if (landed)
        {
            curScore += bufferScore;
        }
        bufferScore = 0;
        score.text = curScore.ToString() + "+" + bufferScore.ToString();
    }
}
