using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }
}
