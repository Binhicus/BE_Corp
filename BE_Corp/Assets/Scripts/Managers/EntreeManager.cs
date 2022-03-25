using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntreeManager : MonoBehaviour
{

    public GameObject fog;
    public GameObject epouvantail;
    public GameObject porteManteau;
    public GameObject Porte;
    public GameObject Pas;


    private void OnEnable()
    {
        epouvantail = GameObject.Find("Epouvantail");
        porteManteau = GameObject.Find("PorteManteau");
        fog = GameObject.Find("Gray Volume Fog");
        EntreeLoader();
    }
    public void EpouvantailState()
    {
        if (PlayerPrefs.GetInt("Scarecrow") == 1)
        {
            epouvantail.SetActive(false);
            porteManteau.SetActive(true);
            porteManteau.GetComponent<Animator>().enabled = false;
        }
    }


    public void FogState()
    {
        fog = GameObject.Find("Gray Volume Fog");
        if (PlayerPrefs.GetInt("Brume") == 1)
        {
            fog.SetActive(false);
        }
        //ajouter seconde condition pour débloquer la porte
    }

    /*public void PorteChambre()
    {

    }*/

    public void EntreeLoader()
    {
        FogState();
        EpouvantailState();
    }
}
