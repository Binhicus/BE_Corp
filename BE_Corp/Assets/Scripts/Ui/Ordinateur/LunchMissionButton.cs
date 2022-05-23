using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LunchMissionButton : MonoBehaviour
{

    public void LunchMission()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
