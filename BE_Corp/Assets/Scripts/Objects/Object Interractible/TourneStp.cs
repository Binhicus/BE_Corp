using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TourneStp : MonoBehaviour
{
    public float rotationSpeed =2f;
    public float ZaxisRotation;


    public GameObject SymbAllume;
    public GameObject TemperaureSymbol;
    public bool estAllume;
    public Color couleurbase;
    public Color couleurchaud;
    public ParticleSystem Smoke;
    public static int TempActuelle;
    public static float posz;
    public bool Please;
    public FourScript fourScript;
    public AudioSource Cran;
    public AudioSource Ventilation;
    //public GameObject TempFour;

    public bool BoutonD;

    public GameObject Ttemp;


    public int Temp0;
    public int Temp1;
    public int Temp2;
    public int Temp3;

    public bool TuPeux1;
    public bool TuPeux2;
    public bool TuPeux3;
    public bool TuPeux4;

    private bool SonAll;
    private bool SonEt;
    public static bool OuaiAllume;
    public GameObject TextTemp;

    // Start is called before the first frame update
    void Start()
    {
        SonEt=true;
        TuPeux2=true;
        TuPeux4=true;
        Cran.volume=0;
    }

    void Awake()
    {
        if(PlayerPrefs.GetInt("Smoke")==4)
        {
            Smoke.Stop();
            Ventilation.volume=0;
            Ventilation.Stop();
        }

        /*if(BoutonD)
        {
             transform.rotation = new Vector3(0.937f, -3.687f, posz);
        }*/
        Please=true;

        if(PlayerPrefs.GetInt("Temper")==480)
        {
            PlayerPrefs.SetInt("Smoke",2);
            fourScript.ApresCramax();
            Smoke.Play();
            Ventilation.volume=0;
            Ventilation.Stop();
        }

        if(PlayerPrefs.GetInt("Smoke")==2)
        {
            PlayerPrefs.SetInt("Four",20);
            PlayerPrefs.SetInt("FourOk",2);
            Smoke.Play();
            Ventilation.volume=0;
            Ventilation.Stop();
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        Ttemp.GetComponent<TextMeshPro>().text=TempActuelle.ToString()+ " °C";
        
       // Debug.Log(PlayerPrefs.GetInt("Smoke"));
       // Debug.Log(TempActuelle);

        //Debug.Log(PlayerPrefs.GetInt("Smoke"));
        if(BoutonD)
        {
            //Debug.Log(this.transform.eulerAngles.z);
        }
        


        if(this.transform.eulerAngles.z>117&&!BoutonD)
        {
            Allume();
        }
        if(this.transform.eulerAngles.z<71&&!BoutonD)
        {
            Eteins();
        }
        if(this.transform.eulerAngles.z>69.7f&&this.transform.eulerAngles.z<144&&BoutonD&&Please)
        {
          //  Debug.Log("C'est pour le 0");
            Temperature0();
        }
        if(this.transform.eulerAngles.z>144f&&this.transform.eulerAngles.z<245&&BoutonD&&Please)
        {
          // Debug.Log("C'est pour le 1");
           Temperature1();
        }
        if(this.transform.eulerAngles.z>245f&&this.transform.eulerAngles.z<340&&BoutonD&&Please)
        {
            //Debug.Log("C'est pour le 2");
            Temperature2();
        }
        if(this.transform.eulerAngles.z<75&&BoutonD&&Please)
        {
            //Debug.Log("C'est pour le 3");
            Temperature3();
        }
    }


    public void Temperature0()
    {
        Debug.Log("F1");
        if(PlayerPrefs.GetInt("Smoke")!=2)
            {
            TempActuelle=0;
            PlayerPrefs.SetInt("Temper",0);
            TemperaureSymbol.SetActive(false);
            Ttemp.GetComponent<TextMeshPro>().color=couleurbase;

            if(TuPeux1==true&&PlayerPrefs.GetInt("FourOk")!=2)
                {
                TuPeux1=false;
                TuPeux2=true;
                TuPeux3=true;
                TuPeux4=true;
                Cran.volume=1;
                Cran.Play();
                Ventilation.Stop();
                }
            }
    }
    public void Temperature1()
    {
         Debug.Log("F2");
            if(PlayerPrefs.GetInt("Smoke")!=2)
            {
                 //Ttemp.GetComponent<TextMeshPro>().text=Temp1.ToString()+ " °";
            TempActuelle=180;
            PlayerPrefs.SetInt("Temper",180);
            
                if(OuaiAllume==true)
             {
                 TemperaureSymbol.SetActive(true);
             }
            
            
            Ttemp.GetComponent<TextMeshPro>().color=couleurbase;


            if(TuPeux2==true&&PlayerPrefs.GetInt("FourOk")!=2)
            {
                TuPeux2=false;
                TuPeux1=true;
                TuPeux3=true;
                TuPeux4=true;
                Cran.volume=1;
                Cran.Play();
                Ventilation.Play();
                Ventilation.volume=0.1f;
            }

            }
       
    }
    public void Temperature2()
    {
         Debug.Log("F3");
        if(PlayerPrefs.GetInt("Smoke")!=2)
            {
        //Ttemp.GetComponent<TextMeshPro>().text=Temp2.ToString()+ " °";
            TempActuelle=360;
            PlayerPrefs.SetInt("Temper",360);
             if(OuaiAllume==true)
             {
                 TemperaureSymbol.SetActive(true);
             }
               
            
            Ttemp.GetComponent<TextMeshPro>().color=couleurbase;


            if(TuPeux3==true&&PlayerPrefs.GetInt("FourOk")!=2)
            {
                TuPeux3=false;
                TuPeux1=true;
                TuPeux2=true;
                TuPeux4=true;
                Cran.volume=1;
                Cran.Play();
                Ventilation.Play();
                Ventilation.volume=0.13f;
            }
            }
        
    }
    public void Temperature3()
    {
        Debug.Log("F4");
        if(PlayerPrefs.GetInt("Smoke")!=2)
            {
        //Ttemp.GetComponent<TextMeshPro>().text=Temp3.ToString()+ " °";
            TempActuelle=480;
           
               if(OuaiAllume==true)
             {
                 TemperaureSymbol.SetActive(true);
             }
            
            PlayerPrefs.SetInt("Temper",480);
            Ttemp.GetComponent<TextMeshPro>().color=couleurchaud;


            if(TuPeux4==true&&PlayerPrefs.GetInt("FourOk")!=2)
            {
                TuPeux4=false;
                TuPeux1=true;
                TuPeux2=true;
                TuPeux3=true;
                Cran.volume=1;
                Cran.Play();
                Ventilation.Play();
                Ventilation.volume=0.15f;
            }

            }
        
    }
     private void OnMouseDrag() 
    {

        ZaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
 
        transform.Rotate(0,0, ZaxisRotation);
        
        
    }

    public void Allume()
    {
        //Debug.Log("Ok");
        SymbAllume.GetComponent<Animator>().SetInteger("All",1);
        Ttemp.SetActive(true);
        TextTemp.SetActive(true);
        OuaiAllume=true;

        if(SonAll==true)
        {
            SonAll=false;
            SonEt=true;
            Cran.volume=1;
            Cran.Play();
        }

    }
    public void Eteins()
    {
       // Debug.Log("Ok");
        SymbAllume.GetComponent<Animator>().SetInteger("All",0);
        Ttemp.SetActive(false);
        TemperaureSymbol.SetActive(false);
        TextTemp.SetActive(false);
        OuaiAllume=false;

        if(SonEt==true)
        {
            SonEt=false;
            SonAll=true;
            Cran.Play();
        }
    }
}
