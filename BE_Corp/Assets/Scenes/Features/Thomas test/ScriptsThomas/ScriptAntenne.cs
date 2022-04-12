using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

     private Vector3 startPosition;
     private bool gagne;
    // Start is called before the first frame update
    void Awake()
    {
        TexteMeteo=GameObject.Find("Nord meteo");
        RadioBug.Play();
        RadioBug.volume=0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        if ((Input.GetMouseButtonDown(0))&&dedans==true&&gagne==false)
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

        if(TowerAngle>11&&TowerAngle<11.5f)
        {

            TexteMeteo.GetComponent<Animator>().SetBool("Trouve", true);
                TexteMeteo.GetComponent<Animator>().SetBool("PasLoin", false);
                RadioBug.volume=0; 

            if(Maintiens==false&&gagne==false)
            {
                TermineMiniJeu();
            }
        }

        if(TowerAngle>10&&TowerAngle<10.9f)
        {
            //Debug.Log("2");
            TexteMeteo.GetComponent<Animator>().SetBool("PasLoin", true);
            RadioBug.volume=0.5f;
            TexteMeteo.GetComponent<Animator>().SetBool("Trouve", false);
        }
        if(TowerAngle>12.6f)
        {
            //Debug.Log("3");
            TexteMeteo.GetComponent<Animator>().SetBool("PasLoin", false);
            TexteMeteo.GetComponent<Animator>().SetBool("Trouve", false);
            RadioBug.volume=0f;
        }
         if(TowerAngle<9f)
        {
            //Debug.Log("4");
            TexteMeteo.GetComponent<Animator>().SetBool("PasLoin", false);
            TexteMeteo.GetComponent<Animator>().SetBool("Trouve", false);
            RadioBug.volume=0f;
        }

        if(TowerAngle>11.6f&&TowerAngle<12.3f)
        {
           // Debug.Log("5");
            TexteMeteo.GetComponent<Animator>().SetBool("Trouve", false);
            TexteMeteo.GetComponent<Animator>().SetBool("PasLoin", true);
            RadioBug.volume=0.5f;
        }
        


    }

    public void TermineMiniJeu()
    {
        gagne=true;
        BulletinMeteo.Play();
        RadioBug.volume=0; 
        TexteMeteo.GetComponent<Animator>().SetBool("Trouve", true);
        PlayerPrefs.SetInt("Parapluie", 1);
    }



private void OnMouseEnter() 
{
    dedans=true;
}

private void OnMouseExit() 
{
    dedans=false;
}

public void Rotate()
{
    TowerAngle += Input.GetAxis("Mouse X") * TowerSpeed * Time.deltaTime;
    //TowerAngle=Mathf.Clamp(TowerAngle,0,-180);

    transform.rotation = Quaternion.Euler(0,0,(TowerAngle*2));
    //Antenne.Rotate (new Vector3 (0, 0, TowerAngle) * Time.deltaTime); 
    //Antenne.localRotation = Quaternion.Euler(0,0,TowerAngle);  */        
}


}

