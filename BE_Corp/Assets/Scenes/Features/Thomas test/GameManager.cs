using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Vase;
    public GameObject Tenebres;

    public GameObject EpouvantailObj;
    public GameObject PorteManteau;
    public GameObject Porte;
    public GameObject Pas;
    public static bool Une;
    public bool Test;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake() {

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
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Une);
    }

    public void EpouvantailOk()
    {
        PlayerPrefs.SetInt("Epouvantail",1);
    }

    public void VaseOk()
    {
        PlayerPrefs.SetInt("Vase",1);
        Vase.transform.position=new Vector3(-0.68f,0.22f,1.806249f);
    }
    public void ChambreOuverte()
    {
        PlayerPrefs.SetInt("Chambre",1);
        Tenebres.SetActive(false);
    }
    public void TenebreOk()
    {
        PlayerPrefs.SetInt("Tenebres",1);
        Tenebres.SetActive(false);
    }
}
