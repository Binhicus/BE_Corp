using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ScriptAntenne : MonoBehaviour
{
    public bool dedans;
    public Transform Antenne;
    public float TowerAngle=-1f;
    public float TowerSpeed;
    public bool Maintiens;
    public AudioSource RadioBug;
    public AudioSource BulletinMeteo;

    public GameObject TexteMeteo;
    public BlockReference maj,parletermine;

     private Vector3 startPosition;
     private bool gagne;
     public float RotZ;
     public AudioSource pluie;
     public float speed;
     private bool Une;
    // Start is called before the first frame update
    void Awake()
    {
        TexteMeteo=GameObject.Find("Nord meteo");
        pluie=GameObject.Find("SonPluie").GetComponent<AudioSource>();
        RadioBug.Play();
        RadioBug.volume=0;
        PlayerPrefs.SetInt("Parapluie", 0);
        //transform.rotation = Quaternion.Euler(0, 0, PlayerPrefs.GetFloat("RotationAntenne"));
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerPrefs.GetInt("Parapluie")==1)
        {
            RadioBug.volume=0;
            RadioBug.Stop();
        }

        TowerAngle=this.transform.rotation.eulerAngles.y;

        Vector3 mousePos = Input.mousePosition;

        if ((Input.GetMouseButtonDown(0))&&dedans==true&&gagne==false&&PlayerPrefs.GetInt("Parapluie")!=1)
        {
            Maintiens=true;
            Debug.Log("click");
        }
        if ((Input.GetMouseButtonUp(0)))
        {
            Maintiens=false;
        }

        if(Maintiens==true&&gagne==false)
        {
            Rotate();
        }

        if(TowerAngle>43&&TowerAngle<46)
        {
            //Debug.Log("1");
            TexteMeteo.GetComponent<Animator>().SetBool("Trouve", true);
                TexteMeteo.GetComponent<Animator>().SetBool("PasLoin", false);

                if(PlayerPrefs.GetInt("Antenne")==1&&PlayerPrefs.GetInt("PileDansRadio")==1&&PlayerPrefs.GetInt("Parapluie")==0)
            {   
                RadioBug.volume=0.015f; 
            }

                if(Maintiens==false)
                {
                    TermineMiniJeu();
                }
            
            
        }

        if(TowerAngle>40&&TowerAngle<43f)
        {
           // Debug.Log("2");
            TexteMeteo.GetComponent<Animator>().SetBool("PasLoin", true);
            TexteMeteo.GetComponent<Animator>().SetBool("Trouve", false);



            if(PlayerPrefs.GetInt("Antenne")==1&&PlayerPrefs.GetInt("PileDansRadio")==1&&PlayerPrefs.GetInt("Parapluie")==0)
            {   
                RadioBug.volume=0.013f; 
            }
        }
        if(TowerAngle>49f)
        {
            //Debug.Log("3");
            TexteMeteo.GetComponent<Animator>().SetBool("PasLoin", false);
            TexteMeteo.GetComponent<Animator>().SetBool("Trouve", false);
            if(PlayerPrefs.GetInt("Antenne")==1&&PlayerPrefs.GetInt("PileDansRadio")==1&&PlayerPrefs.GetInt("Parapluie")==0)
            {   
                RadioBug.volume=0.09f; 
            }
        }
         if(TowerAngle<40f)
        {
           // Debug.Log("4");
            TexteMeteo.GetComponent<Animator>().SetBool("PasLoin", false);
            TexteMeteo.GetComponent<Animator>().SetBool("Trouve", false);
            if(PlayerPrefs.GetInt("Antenne")==1&&PlayerPrefs.GetInt("PileDansRadio")==1&&PlayerPrefs.GetInt("Parapluie")==0)
            {   
                RadioBug.volume=0.09f; 
            }
        }

        if(TowerAngle>46&&TowerAngle<49f)
        {
           // Debug.Log("5");
            TexteMeteo.GetComponent<Animator>().SetBool("Trouve", false);
            TexteMeteo.GetComponent<Animator>().SetBool("PasLoin", true);
           if(PlayerPrefs.GetInt("Antenne")==1&&PlayerPrefs.GetInt("PileDansRadio")==1&&PlayerPrefs.GetInt("Parapluie")==0)
            {   
                RadioBug.volume=0.011f; 
            }
        }

        if(PlayerPrefs.GetInt("Parapluie")==1)
        {
            RadioBug.Stop();
            RadioBug.volume=0;
        }
        


    }

    public void Effet()
    {
        MisAJourEffect.Instance.MiseAJour();
        PlayerPrefs.SetInt("Morceau1Tableau",1);
        pluie.Play();
    }

    public void TermineMiniJeu()
    {
        if(Une==false)
        {
            Une=true;
            RadioBug.Stop();
            StartCoroutine(coroutineA());
        }
        
    }

    IEnumerator coroutineA()
    {
        
        yield return new WaitForSeconds(2.0f);
        BulletinMeteo.Play();
        Debug.Log("ENIGME REUSSIE");
        gagne=true;
        RadioBug.volume=0; 
        TexteMeteo.GetComponent<Animator>().SetBool("Trouve", true);
        PlayerPrefs.SetInt("Parapluie", 1);
        Jauge.Instance.stadeProg += 1;
        yield return new WaitForSeconds(4.0f);
        Debug.Log("Bah");
        parletermine.Execute();
       
    }



private void OnMouseEnter() 
{
    dedans=true;
}

private void OnMouseExit() 
{
    dedans=false;
    PlayerPrefs.SetFloat("RotationAntenne",transform.rotation.eulerAngles.z );
}

public void Rotate()
{
    TowerAngle += Input.GetAxis("Mouse X") * TowerSpeed * Time.deltaTime;
    //TowerAngle=Mathf.Clamp(TowerAngle,0,-180);

    transform.rotation = Quaternion.Euler(0,(TowerAngle*speed),0);
    //Antenne.Rotate (new Vector3 (0, 0, TowerAngle) * Time.deltaTime); 
    //Antenne.localRotation = Quaternion.Euler(0,0,TowerAngle);  */        
}


}

