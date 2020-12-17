using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void ButtonPressSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");

    }

    public void GithubLink()
    {
        
        Application.OpenURL("https://github.com/djstagen/Using-Life/edit/main/README.md");
        
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
