using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoutonFour : MonoBehaviour
{
    public static float ValTemperature;
    public bool Plus;
    public static int CranTemp;

    public int Temp0;
    public int Temp1;
    public int Temp2;
    public int Temp3;
    public int Temp4;
    public int Temp5;
    public int Temp6;

    public GameObject Ttemp;
    public GameObject barre;

    public Vector3 Pos0;
    public Vector3 Pos1;
    public Vector3 Pos2;
    public Vector3 Pos3;
    public Vector3 Pos4;
    public Vector3 Pos5;
    public Vector3 Pos6;

    public ParticleSystem Smoke;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Awake()
    {
        if(PlayerPrefs.GetInt("Four")==2)
        {
            PlayerPrefs.SetInt("Four",3);
        }

        if(PlayerPrefs.GetInt("Four")==3)
        {
            Smoke.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
         Ttemp.GetComponent<TextMeshPro>().text=ValTemperature.ToString()+ " °";

         barre.GetComponent<Animator>().SetInteger("Cran",CranTemp);
    }

     void OnMouseDown()
    {
        if(Plus)
        {
            Debug.Log("1");
            Ajoute();
        }


        if(!Plus)
        {
            Debug.Log("2");
            Enleve();
        }
    }


    public void Ajoute()
    {

        CranTemp+=1;


        if(CranTemp==7)
        {
            CranTemp=0;
        }
        

        if(CranTemp==0)
        {
            ValTemperature=Temp0;
            //barre.transform.position = Pos0;
            PlayerPrefs.SetInt("Four",4);
        }
        if(CranTemp==1)
        {
            ValTemperature=Temp1;
            //barre.transform.position = Pos1;
            PlayerPrefs.SetInt("Four",4);
        }
        if(CranTemp==2)
        {
            ValTemperature=Temp2;
           // barre.transform.position=new Vector3();
           PlayerPrefs.SetInt("Four",4);
        }
        if(CranTemp==3)
        {
            ValTemperature=Temp3;
            //barre.transform.position=new Vector3();
            PlayerPrefs.SetInt("Four",4);
        }
        if(CranTemp==4)
        {
            ValTemperature=Temp4;
            //barre.transform.position=new Vector3();
            PlayerPrefs.SetInt("Four",4);
        }
        if(CranTemp==5)
        {
            ValTemperature=Temp5;
            //barre.transform.position=new Vector3();
            PlayerPrefs.SetInt("Four",4);
        }


        if(CranTemp==6)
        {
            ValTemperature=Temp6;
            //barre.transform.position=new Vector3();
            PlayerPrefs.SetInt("Four",2);
        }
    }

    public void Enleve()
    {
        CranTemp-=1;

        if(CranTemp==-1)
        {
            CranTemp=6;
        }
        

        if(CranTemp==0)
        {
            ValTemperature=Temp0;
        }
        if(CranTemp==1)
        {
            ValTemperature=Temp1;
        }
        if(CranTemp==2)
        {
            ValTemperature=Temp2;
        }
        if(CranTemp==3)
        {
            ValTemperature=Temp3;
        }
        if(CranTemp==4)
        {
            ValTemperature=Temp4;
        }
        if(CranTemp==5)
        {
            ValTemperature=Temp5;
        }
        if(CranTemp==6)
        {
            ValTemperature=Temp6;
            PlayerPrefs.SetInt("Four",2);
        }
    }

}


