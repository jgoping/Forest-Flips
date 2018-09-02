using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public void StartButton()
    {
        SceneManager.LoadScene(2);
	}

    public void CustomizeButton()
    {
        SceneManager.LoadScene(1);
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
