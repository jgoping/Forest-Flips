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
}
