using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntreeManager : MonoBehaviour
{

    public GameObject fog, epouvantail, porteManteau, Porte, Pas, Tournevis, antenne, enveloppe, OuverturePorteChambre;


    private void OnEnable()
    {
        epouvantail = GameObject.Find("Scarecrow");
        porteManteau = GameObject.Find("Coat Rack");
        fog = GameObject.Find("Gray Volume Fog");
        Tournevis = GameObject.Find("Tournevis");
        enveloppe = GameObject.Find("Enveloppe 01");
        EntreeLoader();

    }
    public void EpouvantailState()
    {
        if (PlayerPrefs.GetInt("Scarecrow") == 1)
        {
            epouvantail.SetActive(false);
            porteManteau.SetActive(true);
            //porteManteau.GetComponent<Animator>().SetTrigger("CoatRack Enable");
        }
    }

    public void TournevisState()
    {
        if (PlayerPrefs.GetInt("Tournevis") == 1)
        {
            if(Tournevis != null)
            {
                Tournevis.SetActive(false);
            }
        }
    }

    /*public void AntenneState()
    {
        if (PlayerPrefs.GetInt("Antenne") == 1)
        {
            if(antenne != null)
            {
                antenne.SetActive(false);
            }

        }
    }*/

    public void FogState()
    {
        fog = GameObject.Find("Gray Volume Fog");
        if (PlayerPrefs.GetInt("Brume") == 1)
        {
            if(fog != null)
            {
                fog.SetActive(false);
            }
        }
        //ajouter seconde condition pour débloquer la porte
    }

    public void PorteChambreState()
    {
        OuverturePorteChambre = GameObject.Find("Gray Volume Fog");
        if (PlayerPrefs.GetInt("Porte Ouverte") == 0)
        {
            if (OuverturePorteChambre != null)
            {
                OuverturePorteChambre.GetComponent<BoxCollider>().enabled = true;
            }
        }
        else if (PlayerPrefs.GetInt("Porte Ouverte") == 1)
        {
            if(OuverturePorteChambre != null)
            {
                OuverturePorteChambre.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    public void IntroState()
    {
        Tournevis.GetComponent<CapsuleCollider>().enabled = true;
        epouvantail.GetComponent<BoxCollider>().enabled = true;
        if (PlayerPrefs.GetInt("Brume") == 0) 
        { 
            fog.GetComponent<BoxCollider>().enabled = true;
        }
        else if (PlayerPrefs.GetInt("Brume") == 1)
        {
            fog.GetComponent<BoxCollider>().enabled = false;
        }

        enveloppe.GetComponent<BoxCollider>().enabled = true;
        
    } 

    public void EntreeLoader()
    {
        TournevisState();
        //AntenneState();
        PorteChambreState();
        FogState();
        EpouvantailState();
        if (PlayerPrefs.GetInt("Séquence 1 Done") == 1)
        {
            IntroState();
        }
    }
}
