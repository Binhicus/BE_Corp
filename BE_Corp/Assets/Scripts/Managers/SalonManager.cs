using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalonManager : MonoBehaviour
{
    public GameObject vase;
    public GameObject key;
    public GameObject objetsMeteo;
    public GameObject PilesRobot;
    public GameObject ballon, antenne;
    public GameObject salonAvant, salonApres;

    private void OnEnable()
    {
        vase = GameObject.Find("Switch");
        key = GameObject.Find("I_Clef");
        objetsMeteo = GameObject.Find("Umbrella");
        PilesRobot = GameObject.FindWithTag("Test");
        ballon = GameObject.Find("Soccer Ball").transform.GetChild(0).gameObject;
        antenne = GameObject.Find("Antenne");

        SalonLoader();
    }

    void Awake()
    {
        //PlayerPrefs.SetInt("Salon Révélé",1);
    }
    public void VaseState()
    {
        //PlayerPrefs.SetInt("Vase",1);
        //Vase.transform.position=new Vector3(-0.68f,0.22f,1.806249f);

        if (PlayerPrefs.GetInt("VaseAndKey") == 1) //            le joueur a cassé le vase mais n'a pas ramassé la clef
        {
            vase.SetActive(false);
            ballon.SetActive(false);
            key.SetActive(true);
        }
        if (PlayerPrefs.GetInt("VaseAndKey") == 2) //            le joueur a cassé le vase mais et a ramassé la clef
        {
            vase.SetActive(false);
            ballon.SetActive(false);
            key.SetActive(false);
        }
    }

    public void PilesState()
    {
        //Debug.Log(PlayerPrefs.GetInt("Piles"));
        
        if (PlayerPrefs.GetInt("Piles") == 0) //            le joueur n'a pas encore utilisé le tournevis
        {
            PilesRobot.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Piles") == 1) //            le joueur a utilisé le tournevis mais pas ramassé les piles
        {
            PilesRobot.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Piles") == 2) //            le joueur a bien fait son job
        {
             PilesRobot.SetActive(false);
        }
    }

    public void AntenneState()
    {
        if (PlayerPrefs.GetInt("Antenne") == 1)
        {
            if (antenne != null)
            {
                antenne.SetActive(false);
            }

        }
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

    public void SalonState() 
    { 
        if(PlayerPrefs.GetInt("Salon Révélé") == 0)
        {
            salonAvant.SetActive(true);
            salonApres.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Salon Révélé") == 1)
        {
            salonAvant.SetActive(false);
            salonApres.SetActive(true);
        }
    }

    public void SalonLoader()
    {
        SalonState();
        VaseState();
        UmbrellaState();
        AntenneState();
        PilesState();
    }
}
