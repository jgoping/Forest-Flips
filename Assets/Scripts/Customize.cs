using UnityEngine;
using UnityEngine.SceneManagement;

public class Customize : MonoBehaviour
{
    public Renderer[] rend;

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ColourChange(Material colour)
    {
        rend[0].material = colour;
        rend[1].material = colour;
        SceneManager.LoadScene(1);
    }
}
