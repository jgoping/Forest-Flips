using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour {

    public float minutesLeft;
    public Text timeDisplay;
	
	void Update () {
        minutesLeft -= Time.deltaTime;
        timeDisplay.text = string.Format("{0:0.00}", minutesLeft);

        if (minutesLeft <= 0)
        {
            SceneManager.LoadScene(3);
        }
	}
}
