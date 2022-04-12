using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();

    }
    // Start is called before the first frame update

    /*private void Awake() {

        if(!Une)
        {
            Une=true;
            PlayerPrefs.DeleteAll(); 
        }
        if(PlayerPrefs.GetInt("Epouvantail")==1&&!Test)
        {
           EpouvantailObj.SetActive(false);
           PorteManteau.SetActive(true);
           PorteManteau.GetComponent<Animator>().SetTrigger("Ouvert");
           Porte.GetComponent<Animator>().SetTrigger("Ouvert");
           Pas.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Vase")==1&&!Test)
        {
            Debug.Log("Vase Cassé");
            Vase.transform.position=new Vector3(-0.68f,0.22f,1.806249f);
        }
        if(PlayerPrefs.GetInt("Tenebres")==1&&!Test)
        {
             PlayerPrefs.SetInt("Tenebres", 0);
             Tenebres.SetActive(false);

        }

        /*if(Test==true)
        {
            PlayerPrefs.SetInt("Vase", 0);
            PlayerPrefs.SetInt("Tenebres", 0);
            Vase.transform.position=new Vector3(0.047f,1.628f,1.806249f);
            Tenebres.SetActive(true);
        }*/
 

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(PlayerPrefs.GetInt("Tenebres"));
    }
    
    #region Objets dans l'entrée

    public GameObject fog;
    public GameObject epouvantail;
    public GameObject porteManteau;
    public GameObject Porte;
    public GameObject Pas; 
    
    public void EpouvantailState()
    {
        epouvantail = GameObject.Find("Epouvantail");
        porteManteau = GameObject.Find("PorteManteau");
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
        if(PlayerPrefs.GetInt("Brume") == 1)
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
    /*public void FogState()
    {
        Debug.Log("OK BAK");
        PlayerPrefs.SetInt("Tenebres",1);
        fog.SetActive(false);


    }*/

    #endregion

    #region Objets dans le salon

    public GameObject vase;
    public GameObject key;
    public GameObject objetsMeteo;

    public void VaseState()
    {
        //PlayerPrefs.SetInt("Vase",1);
        //Vase.transform.position=new Vector3(-0.68f,0.22f,1.806249f);
        vase = GameObject.Find("Switch");
        key = GameObject.Find("I_Clef");
        if(PlayerPrefs.GetInt("VaseAndKey") == 1) //            le joueur a cassé le vase mais n'a pas ramassé la clef
        {
            vase.SetActive(false);
            key.SetActive(true);
        }
        if (PlayerPrefs.GetInt("VaseAndKey") == 2) //            le joueur a cassé le vase mais et a ramassé la clef
        {
            vase.SetActive(false);
            key.SetActive(false);
        }
    }

    public void UmbrellaState()
    {
        /*objetsMeteo = GameObject.FindGameObjectsWithTag("Météo");
        if(PlayerPrefs.GetInt("Parapluie") == 0)
        {
            foreach (GameObject tagged in objetsMeteo)
            {
                tagged.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("Parapluie") == 1)
        {
            foreach (GameObject tagged in objetsMeteo)
            {
                tagged.SetActive(true);
            }
        }*/

        objetsMeteo = GameObject.Find("Umbrella");
        if(objetsMeteo != null)
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

    public void SalonLoader()
    {
        VaseState();
        UmbrellaState();
    }



    #endregion

    #region Objets dans la Cuisine

    public GameObject zoneCachée;

    public void HiddenArea()
    {
        zoneCachée = GameObject.Find("Cuisine - Partie 2");
        if(PlayerPrefs.GetInt("Cuisine") == 1)
        {
            zoneCachée.SetActive(true);
        }
    }








    #endregion
}
