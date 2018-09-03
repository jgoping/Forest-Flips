using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour
{
    public Text score;

    public void Start()
    {
        score.text += Score.scoreForFinish;
    }
    public void FinishButton()
    {
        SceneManager.LoadScene(0);
    }
}
