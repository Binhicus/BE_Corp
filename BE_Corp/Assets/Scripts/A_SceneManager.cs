using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class A_SceneManager : MonoBehaviour
{
    //permet de changer de scène grace à des boutons

    public string mainMenu;
    public string settingsMenu;
    public string tutorialLevel;
    public void mainMenuScene()
    {
        SceneManager.LoadScene(mainMenu);
        
    }

    public void settingsMenuScene()
    {
        SceneManager.LoadScene(settingsMenu);
    }

    public void tutorialLevelScene()
    {
        SceneManager.LoadScene(tutorialLevel);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
