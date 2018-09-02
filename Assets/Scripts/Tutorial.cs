using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public Text tutorialText;
    public Text score;

    private int stage = 0;
    private bool forward = false;
    private bool left = false;
    private bool right = false;
    private int initialScore;

	void Update () {
        if (stage == 0)
        {
            BasicMovementCheck();
        }
        else if (stage == 1)
        {
            JumpCheck();
        }
        else if (stage == 2)
        {
            KickFlipCheck();
        }
        ExitCheck();
    }

    void BasicMovementCheck()
    {
        if (Input.GetKey("w") && !forward)
        {
            forward = true;
        }
        if (Input.GetKey("a") && !left)
        {
            left = true;
        }
        if (Input.GetKey("d") && !right)
        {
            right = true;
        }

        if (forward && left && right)
        {
            stage = 1;
            tutorialText.text = "Now try jumping using the spacebar!";
        }
    }

    void JumpCheck()
    {
        if (Input.GetKey("space"))
        {
            stage = 2;
            tutorialText.text = "Hold A or D in the air to do a flip! \n" +
                "This will score you 50 points!";
            initialScore = Int32.Parse(score.text.Split('+')[0]);
        }
    }

    void KickFlipCheck()
    {
        if (Int32.Parse(score.text.Split('+')[0]) >= initialScore + 50)
        {
            stage = 3;
            tutorialText.text = "Congratulations! You have the basic controls down! \n" +
                "Now try the full game and get creative! \n" +
                "Press the escape key to return to the main menu.";
        }
    }

    void ExitCheck()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
