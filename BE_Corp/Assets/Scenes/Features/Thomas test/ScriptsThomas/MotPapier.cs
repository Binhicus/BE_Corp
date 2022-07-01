using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotPapier : MonoBehaviour
{
    public bool Dessus;
    public bool deplace;
    public int NumeroChapitre;
    public int jeSuisSurLaPlace;


    public int SurvoleLaZone;


    public static bool place1Prise;
    public static bool place2Prise;
    public static bool place3Prise;
    public static bool place4Prise;
    public static bool place5Prise;
    public static bool place6Prise;

    public static float BonneReponse;


    public bool Survole1;
    private bool Survole2;
    private bool Survole3;
    private bool Survole4;
    private bool Survole5;
    private bool Survole6;
    public Color ColorNormal;
    public Color ColorPlace;
    public Color couleurtouche;

    public int TrouveouPas;
    
    public static bool Une;

    public float BonneAnswer;

    public bool Termine;

    public bool Prem;
    public bool Deux;
    public bool Trois;
    public bool Quatre;
    public bool Cinq;
    public bool Six;

    public GameObject Book;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    void Awake()
    {
        if(PlayerPrefs.GetInt("Cuisine Révélée")==1)
        {
            if(NumeroChapitre==1)
            {
                this.GetComponent<RectTransform>().localPosition=new Vector3(163f,81f,0);
            }
            if(NumeroChapitre==2)
            {
                this.GetComponent<RectTransform>().localPosition=new Vector3(146f,41f,0);
            }
            if(NumeroChapitre==3)
            {
                 this.GetComponent<RectTransform>().localPosition=new Vector3(128f,-2f,0);
            }
            if(NumeroChapitre==4)
            {
                this.GetComponent<RectTransform>().localPosition=new Vector3(118f,-50f,0);
            }
            if(NumeroChapitre==5)
            {
                this.GetComponent<RectTransform>().localPosition=new Vector3(101f,-91f,0);
            }
            if(NumeroChapitre==6)
            {
                this.GetComponent<RectTransform>().localPosition=new Vector3(87f,-135f,0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        BonneAnswer=BonneReponse;
        if (Input.GetMouseButtonDown(0)&&Dessus&&!Termine&&PlayerPrefs.GetInt("Cuisine Révélée")!=1)
        {
             deplace=true;
             this.GetComponentInChildren<Image>().color=couleurtouche;
        }

        if (Input.GetMouseButtonUp(0)&&PlayerPrefs.GetInt("Cuisine Révélée")!=1)
        {
            deplace=false;
        }
        if(deplace&&PlayerPrefs.GetInt("Cuisine Révélée")!=1)
        {
            transform.position = new Vector3(Input.mousePosition.x+450,Input.mousePosition.y+100,0);
        }
        if(deplace==false&&Survole1&&!place1Prise)
        {
            Place1();
        }
        if(deplace==false&&Survole2&&!place2Prise)
        {
            Place2();
        }
        if(deplace==false&&Survole3&&!place3Prise)
        {
            Place3();
        }
        if(deplace==false&&Survole4&&!place4Prise)
        {
            Place4();
        }
        if(deplace==false&&Survole5&&!place5Prise)
        {
            Place5();
        }
        if(deplace==false&&Survole6&&!place6Prise)
        {
            Place6();
        }


        // POUR CHAPITRE 1
        if(this.GetComponent<RectTransform>().localPosition.x>75f&&this.GetComponent<RectTransform>().localPosition.x<245f&&this.GetComponent<RectTransform>().localPosition.y>79f&&this.GetComponent<RectTransform>().localPosition.y<107f)
        {
            Survole1=true;
        }
        else
        {
            place1Prise=false;
            Survole1=false;

            if(NumeroChapitre==1&&Prem==true)
            {
                Prem=false;
                BonneReponse-=1;
            }
        }

         //POUR CHAPITRE 2
        if(this.GetComponent<RectTransform>().localPosition.x>58f&&this.GetComponent<RectTransform>().localPosition.x<212f&&this.GetComponent<RectTransform>().localPosition.y>32.5f&&this.GetComponent<RectTransform>().localPosition.y<74f)
        {
            Survole2=true;
        }
        else
        {
            place2Prise=false;
            place2Prise=false;
            Survole2=false;
            if(NumeroChapitre==2&&Deux==true)
            {
                Deux=false;
                BonneReponse-=1;
                //place1Prise=false;
            }
        }

        // POUR CHAPITRE 3
        if(this.GetComponent<RectTransform>().localPosition.x>36.7f&&this.GetComponent<RectTransform>().localPosition.x<197f&&this.GetComponent<RectTransform>().localPosition.y>-10.8f&&this.GetComponent<RectTransform>().localPosition.y<25.4f)
        {
            Survole3=true;
        }
        else
        {
            place3Prise=false;
            Survole3=false;
            if(NumeroChapitre==3&&Trois==true)
            {
                Trois=false;
                BonneReponse-=1;
                //place1Prise=false;
            }
        }

         // POUR CHAPITRE 4
        if(this.GetComponent<RectTransform>().localPosition.x>34.6f&&this.GetComponent<RectTransform>().localPosition.x<185f&&this.GetComponent<RectTransform>().localPosition.y>-68.3f&&this.GetComponent<RectTransform>().localPosition.y<-22.4f)
        {
            Survole4=true;
        }
        else
        {
            place4Prise=false;
            Survole4=false;
            if(NumeroChapitre==4&&Quatre==true)
            {
                Quatre=false;
                BonneReponse-=1;
                //place1Prise=false;
            }
        }

         //POUR CHAPITRE 5
        if(this.GetComponent<RectTransform>().localPosition.x>11.8f&&this.GetComponent<RectTransform>().localPosition.x<172f&&this.GetComponent<RectTransform>().localPosition.y>-104f&&this.GetComponent<RectTransform>().localPosition.y<-65f)
        {
            Survole5=true;
        }
        else
        {
            place5Prise=false;
            Survole5=false;
            if(NumeroChapitre==5&&Cinq==true)
            {
                Cinq=false;
                BonneReponse-=1;
                //place1Prise=false;
            }
        }

        // POUR CHAPITRE 6
        if(this.GetComponent<RectTransform>().localPosition.x>9.8f&&this.GetComponent<RectTransform>().localPosition.x<165f&&this.GetComponent<RectTransform>().localPosition.y>-164f&&this.GetComponent<RectTransform>().localPosition.y<-95f)
        {
            Survole6=true;
        }
        else
        {
            place6Prise=false;
            Survole6=false;
            if(NumeroChapitre==6&&Six==true)
            {
                Six=false;
                BonneReponse-=1;
                //place1Prise=false;
            }
        }
            
    }

    public void SourisOn()
    {
        if(!Termine)
        {
            this.GetComponentInChildren<Image>().color=couleurtouche;
        Dessus=true;
        }
        
    }

    public void SourisOff()
    {
        if(!Termine)
        {
            this.GetComponentInChildren<Image>().color=ColorNormal;
        Dessus=false;
        }
        
    }

    public void Terminado()
    {
        Debug.Log("Termine");
        if(Une==false)
        {
            Une=true;
            Book.GetComponent<Animator>().SetTrigger("Apparait");
            StartCoroutine(coroutineA());

        }
        
    }

    public void Place1()
    {     
    this.GetComponentInChildren<Image>().color=ColorPlace;
    place1Prise=true;
    jeSuisSurLaPlace=1;
    this.GetComponent<RectTransform>().localPosition=new Vector3(163f,81f,0);

    if(NumeroChapitre==1&&!Prem)
    {
        Prem=true;
        BonneReponse+=1;

        if(BonneReponse>=6&&PlayerPrefs.GetInt("Cuisine Révélée")!=1)
        {
            Terminado();
        }
    }
        
    }

    public void Place2()
    {
        this.GetComponentInChildren<Image>().color=ColorPlace;
        place2Prise=true;
        jeSuisSurLaPlace=2;
        this.GetComponent<RectTransform>().localPosition=new Vector3(146f,41f,0);
        if(NumeroChapitre==2&&!Deux)
    {
        Deux=true;
        BonneReponse+=1;

        if(BonneReponse>=6&&PlayerPrefs.GetInt("Cuisine Révélée")!=1)
        {
            Terminado();
        }
    }

    }
    public void Place3()
    {
         this.GetComponentInChildren<Image>().color=ColorPlace;
        place3Prise=true;
        jeSuisSurLaPlace=3;
        this.GetComponent<RectTransform>().localPosition=new Vector3(128f,-2f,0);
        if(NumeroChapitre==3&&!Trois)
    {
        Trois=true;
        BonneReponse+=1;

        if(BonneReponse>=6&&PlayerPrefs.GetInt("Cuisine Révélée")!=1)
        {
            Terminado();
        }
    }
    }
    public void Place4()
    {
         this.GetComponentInChildren<Image>().color=ColorPlace;
        place4Prise=true;
        jeSuisSurLaPlace=4;
        this.GetComponent<RectTransform>().localPosition=new Vector3(118f,-50f,0);
        if(NumeroChapitre==4&&!Quatre)
    {
        Quatre=true;
        BonneReponse+=1;

        if(BonneReponse>=6&&PlayerPrefs.GetInt("Cuisine Révélée")!=1)
        {
            Terminado();
        }
    }
    }
    public void Place5()
    {
         this.GetComponentInChildren<Image>().color=ColorPlace;
        place5Prise=true;
        jeSuisSurLaPlace=5;
        this.GetComponent<RectTransform>().localPosition=new Vector3(101f,-91f,0);
        if(NumeroChapitre==5&&!Cinq)
    {
        Cinq=true;
        BonneReponse+=1;

        if(BonneReponse>=6&&PlayerPrefs.GetInt("Cuisine Révélée")!=1)
        {
            Terminado();
        }
    }
    }
    public void Place6()
    {
         this.GetComponentInChildren<Image>().color=ColorPlace;
        place6Prise=true;
        jeSuisSurLaPlace=6;
        this.GetComponent<RectTransform>().localPosition=new Vector3(87f,-135f,0);
        if(NumeroChapitre==6&&!Six)
    {
        Six=true;
        BonneReponse+=1;

        if(BonneReponse>=6&&PlayerPrefs.GetInt("Cuisine Révélée")!=1)
        {
            Terminado();
        }
    }
    }


    IEnumerator coroutineA()
    {
        
        yield return new WaitForSeconds(4.0f);
        PlayerPrefs.SetInt("Cuisine Révélée",1);
        MisAJourEffect.Instance.MiseAJour();
        Jauge.Instance.stadeProg += 1;
    }
}
