using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    public void FinishButton()
    {
        SceneManager.LoadScene(0);
    }
}
