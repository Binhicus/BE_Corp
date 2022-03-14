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


    public static bool Place1Prise;
    public static bool Place2Prise;
    public static bool Place3Prise;
    public static bool Place4Prise;
    public static bool Place5Prise;
    public static bool Place6Prise;

    public static float BonneReponse;


    private bool Survole1;
    private bool Survole2;
    private bool Survole3;
    private bool Survole4;
    private bool Survole5;
    private bool Survole6;
    public Color ColorNormal;
    public Color ColorPlace;

    public float BonneAnswer;

    public bool Termine;

    public GameObject FiniTrouve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BonneAnswer=BonneReponse;

        Debug.Log(BonneAnswer);

        Debug.Log(Place1Prise);
        if (Input.GetMouseButtonDown(0)&&Dessus&&!Termine)
        {
             deplace=true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            deplace=false;
        }
        if(deplace)
        {
            transform.position = Input.mousePosition;
        }

        if(deplace==false&&Survole1&&Place1Prise==false)
        {
            Place1();
        }
        if(deplace==false&&Survole2&&Place2Prise==false)
        {
            Place2();
        }
        if(deplace==false&&Survole3&&Place3Prise==false)
        {
            Place3();
        }
        if(deplace==false&&Survole4&&Place4Prise==false)
        {
            Place4();
        }
        if(deplace==false&&Survole5&&Place5Prise==false)
        {
            Place5();
        }
        if(deplace==false&&Survole6&&Place6Prise==false)
        {
            Place6();
        }


        // POUR CHAPITRE 1
        if(this.GetComponent<RectTransform>().localPosition.x<-35f&&this.GetComponent<RectTransform>().localPosition.x>-71&&this.GetComponent<RectTransform>().localPosition.y<121&&this.GetComponent<RectTransform>().localPosition.y>102)
        {
        Survole1=true;
        }
        else
        {
            Survole1=false;

            if(jeSuisSurLaPlace==1)
            {
                this.gameObject.transform.GetChild(0).GetComponent<Image>().color=ColorNormal;
                Place1Prise=false;
                jeSuisSurLaPlace=0;

                if(NumeroChapitre==1)
                {
                    BonneReponse-=1;
                }
            }
        }

        // POUR CHAPITRE 2
        if(this.GetComponent<RectTransform>().localPosition.x<-47f&&this.GetComponent<RectTransform>().localPosition.x>-74&&this.GetComponent<RectTransform>().localPosition.y<81&&this.GetComponent<RectTransform>().localPosition.y>68)
        {
        Survole2=true;
        }
        else
        {
            Survole2=false;

            if(jeSuisSurLaPlace==2)
            {
                this.gameObject.transform.GetChild(0).GetComponent<Image>().color=ColorNormal;
                Place2Prise=false;
                jeSuisSurLaPlace=0;

                if(NumeroChapitre==2)
                {
                    BonneReponse-=1;
                }
            }
        }

        // POUR CHAPITRE 3
        if(this.GetComponent<RectTransform>().localPosition.x<-49f&&this.GetComponent<RectTransform>().localPosition.x>-97&&this.GetComponent<RectTransform>().localPosition.y<46&&this.GetComponent<RectTransform>().localPosition.y>23)
        {
        Survole3=true;
        }
        else
        {
            Survole3=false;

            if(jeSuisSurLaPlace==3)
            {
                this.gameObject.transform.GetChild(0).GetComponent<Image>().color=ColorNormal;
                Place3Prise=false;
                jeSuisSurLaPlace=0;

                if(NumeroChapitre==3)
                {
                    BonneReponse-=1;
                }
            }
        }

         // POUR CHAPITRE 4
        if(this.GetComponent<RectTransform>().localPosition.x<-53f&&this.GetComponent<RectTransform>().localPosition.x>-112&&this.GetComponent<RectTransform>().localPosition.y<-1&&this.GetComponent<RectTransform>().localPosition.y>-10.81f)
        {
        Survole4=true;
        }
        else
        {
            Survole4=false;

            if(jeSuisSurLaPlace==4)
            {
                this.gameObject.transform.GetChild(0).GetComponent<Image>().color=ColorNormal;
                Place4Prise=false;
                jeSuisSurLaPlace=0;

                if(NumeroChapitre==4)
                {
                    BonneReponse-=1;
                }
            }
        }

        // POUR CHAPITRE 5
        if(this.GetComponent<RectTransform>().localPosition.x<-76f&&this.GetComponent<RectTransform>().localPosition.x>-121&&this.GetComponent<RectTransform>().localPosition.y<-38&&this.GetComponent<RectTransform>().localPosition.y>-56f)
        {
        Survole5=true;
        }
        else
        {
            Survole5=false;

            if(jeSuisSurLaPlace==5)
            {
                this.gameObject.transform.GetChild(0).GetComponent<Image>().color=ColorNormal;
                Place5Prise=false;
                jeSuisSurLaPlace=0;

                if(NumeroChapitre==5)
                {
                    BonneReponse-=1;
                }
            }
        }

        // POUR CHAPITRE 6
        if(this.GetComponent<RectTransform>().localPosition.x<-89f&&this.GetComponent<RectTransform>().localPosition.x>-136&&this.GetComponent<RectTransform>().localPosition.y<-81&&this.GetComponent<RectTransform>().localPosition.y>-103f)
        {
        Survole6=true;
        }
        else
        {
            Survole6=false;

            if(jeSuisSurLaPlace==6)
            {
                this.gameObject.transform.GetChild(0).GetComponent<Image>().color=ColorNormal;
                Place6Prise=false;
                jeSuisSurLaPlace=0;

                if(NumeroChapitre==6)
                {
                    BonneReponse-=1;
                }
            }
        }
        
            
    }

    public void SourisOn()
    {
        if(!Termine)
        {
            this.GetComponent<Image>().enabled=true;
        Dessus=true;
        }
        
    }

    public void SourisOff()
    {
        if(!Termine)
        {
            this.GetComponent<Image>().enabled=false;
        Dessus=false;
        }
        
    }

    public void Place1()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color=ColorPlace;
        Place1Prise=true;
        jeSuisSurLaPlace=1;
        this.GetComponent<RectTransform>().localPosition=new Vector3(-56.3f,110.3f,0);

        if(NumeroChapitre==jeSuisSurLaPlace)
        {
            BonneReponse+=1;


            if(BonneReponse==6)
            {
                FiniTrouve.SetActive(true);
            }
        }
    }

    public void Place2()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color=ColorPlace;
        Place2Prise=true;
        jeSuisSurLaPlace=2;
        this.GetComponent<RectTransform>().localPosition=new Vector3(-67f,71f,0);

        if(NumeroChapitre==jeSuisSurLaPlace)
        {
            BonneReponse+=1;

            if(BonneReponse==6)
            {
                FiniTrouve.SetActive(true);
            }
        }
    }
    public void Place3()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color=ColorPlace;
        Place3Prise=true;
        jeSuisSurLaPlace=3;
        this.GetComponent<RectTransform>().localPosition=new Vector3(-80.7f,32.1f,0);

        if(NumeroChapitre==jeSuisSurLaPlace)
        {
            BonneReponse+=1;

            if(BonneReponse==6)
            {
                FiniTrouve.SetActive(true);
            }
        }
    }
    public void Place4()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color=ColorPlace;
        Place4Prise=true;
        jeSuisSurLaPlace=4;
        this.GetComponent<RectTransform>().localPosition=new Vector3(-91f,-7.55f,0);

        if(NumeroChapitre==jeSuisSurLaPlace)
        {
            BonneReponse+=1;

            if(BonneReponse==6)
            {
                FiniTrouve.SetActive(true);
            }
        }
    }
    public void Place5()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color=ColorPlace;
        Place5Prise=true;
        jeSuisSurLaPlace=5;
        this.GetComponent<RectTransform>().localPosition=new Vector3(-108f,-48f,0);

        if(NumeroChapitre==jeSuisSurLaPlace)
        {
            BonneReponse+=1;

            if(BonneReponse==6)
            {
                FiniTrouve.SetActive(true);
            }
        }
    }
    public void Place6()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Image>().color=ColorPlace;
        Place6Prise=true;
        jeSuisSurLaPlace=6;
        this.GetComponent<RectTransform>().localPosition=new Vector3(-118f,-88f,0);

        if(NumeroChapitre==jeSuisSurLaPlace)
        {
            BonneReponse+=1;

            if(BonneReponse==6)
            {
                FiniTrouve.SetActive(true);
            }
        }
    }
}
