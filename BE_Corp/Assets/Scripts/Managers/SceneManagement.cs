using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Level1IsFinish()
    {
        PlayerPrefs.SetInt("Mission1Finish", 1);
    }
}
