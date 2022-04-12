using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalonManager : MonoBehaviour
{
    public GameObject vase;
    public GameObject key;
    public GameObject objetsMeteo;
    public GameObject PilesRobot;
    public KickBall ballon;

    private void OnEnable()
    {
        vase = GameObject.Find("Switch");
        key = GameObject.Find("I_Clef");
        objetsMeteo = GameObject.Find("Umbrella");
        PilesRobot = GameObject.FindWithTag("Test");
        ballon = GameObject.Find("Soccer Ball").GetComponent<KickBall>();
        SalonLoader();
    }
    public void VaseState()
    {
        //PlayerPrefs.SetInt("Vase",1);
        //Vase.transform.position=new Vector3(-0.68f,0.22f,1.806249f);

        if (PlayerPrefs.GetInt("VaseAndKey") == 1) //            le joueur a cassé le vase mais n'a pas ramassé la clef
        {
            vase.SetActive(false);
            Destroy(ballon);
            key.SetActive(true);
        }
        if (PlayerPrefs.GetInt("VaseAndKey") == 2) //            le joueur a cassé le vase mais et a ramassé la clef
        {
            vase.SetActive(false);
            Destroy(ballon);
            //key.SetActive(false);
        }
    }

    public void PilesState()
    {
        /*Debug.Log(PlayerPrefs.GetInt("Piles"));
        
        if (PlayerPrefs.GetInt("Piles") == 0) //            le joueur a cassé le vase mais n'a pas ramassé la clef
        {
            PilesRobot.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Piles") == 1) //            le joueur a cassé le vase mais n'a pas ramassé la clef
        {
            PilesRobot.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Piles") == 2) //            le joueur a cassé le vase mais n'a pas ramassé la clef
        {
             PilesRobot.SetActive(false);
        }*/
    }

    public void UmbrellaState()
    {
        if (objetsMeteo != null)
        {
            if (PlayerPrefs.GetInt("Parapluie") == 0)
            {
                objetsMeteo.SetActive(false);
            }
            if (PlayerPrefs.GetInt("Parapluie") == 1)
            {
                objetsMeteo.SetActive(true);
            }
        }
    }

    public void SalonState() { }

    public void SalonLoader()
    {
        VaseState();
        UmbrellaState();
        PilesState();
    }
}
