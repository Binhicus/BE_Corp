using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnFirstRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Mission Started")== 0)
        {
            LoadFirstRoom();
        }
    }

    // Update is called once per frame
    void LoadFirstRoom()
    {
        SceneManager.LoadSceneAsync("EntréeTemp", LoadSceneMode.Additive);
        PlayerPrefs.SetInt("Mission Started", 1);
        PlayerPrefs.SetInt("Salon Reveal", 0);
    }
}
