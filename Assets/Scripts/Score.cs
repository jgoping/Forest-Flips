using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text score;
    private Boolean onRail = false;

    void Update () {
        if (onRail)
        {
            int scoreVal;
            Int32.TryParse(score.text, out scoreVal);
            score.text = (scoreVal + 5).ToString();
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
        int scoreVal;
        Int32.TryParse(score.text, out scoreVal);
        score.text = (scoreVal + 50).ToString();
    }
}
