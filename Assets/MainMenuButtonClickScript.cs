using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonClickScript : MonoBehaviour
{
    public void onPlayClick()
    {
        SceneManager.LoadScene(1);
    }

    public void onQuitClick()
    {
        Application.Quit();
    }
}
