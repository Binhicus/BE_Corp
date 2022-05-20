using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LunchMissionButton : MonoBehaviour
{

    public void LunchMission()
    {
        SceneManager.LoadScene("Gameplay");
    }

    void LoadFirstRoom()
    {
        SceneManager.LoadSceneAsync("EntréeTemp", LoadSceneMode.Additive);
    }

}
