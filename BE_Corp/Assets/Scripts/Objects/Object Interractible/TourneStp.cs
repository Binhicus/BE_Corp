using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TourneStp : MonoBehaviour
{
    public float rotationSpeed =2f;
    public float ZaxisRotation;


    public GameObject SymbAllume;
    public bool estAllume;
    public Color couleurbase;
    public Color couleurchaud;
    public ParticleSystem Smoke;
    public static int TempActuelle;
    public static float posz;
    public bool Please;
    //public GameObject TempFour;

    public bool BoutonD;

    public GameObject Ttemp;


    public int Temp0;
    public int Temp1;
    public int Temp2;
    public int Temp3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        if(PlayerPrefs.GetInt("Smoke")==4)
        {
            Smoke.Stop();
        }

        /*if(BoutonD)
        {
             transform.rotation = new Vector3(0.937f, -3.687f, posz);
        }*/
        Please=false;

        if(PlayerPrefs.GetInt("Temper")==480)
        {
            PlayerPrefs.SetInt("Smoke",2);
            Smoke.Play();
        }

        if(PlayerPrefs.GetInt("Smoke")==2)
        {
            Smoke.Play();
        }

        StartCoroutine(coroutineA());
           
    }

    // Update is called once per frame
    void Update()
    {
        Ttemp.GetComponent<TextMeshPro>().text=TempActuelle.ToString()+ " °";
        
        Debug.Log(PlayerPrefs.GetInt("Smoke"));
        Debug.Log(TempActuelle);

        //Debug.Log(PlayerPrefs.GetInt("Smoke"));
        //Debug.Log(this.transform.eulerAngles.z);


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
            
            Temperature0();
        }
        if(this.transform.eulerAngles.z>144f&&this.transform.eulerAngles.z<245&&BoutonD&&Please)
        {
           
           Temperature1();
        }
        if(this.transform.eulerAngles.z>245f&&this.transform.eulerAngles.z<340&&BoutonD&&Please)
        {
            
            Temperature2();
        }
        if(this.transform.eulerAngles.z<75&&BoutonD&&Please)
        {
            
            Temperature3();
        }
    }


    public void Temperature0()
    {
        Debug.Log("F1");
            //Ttemp.GetComponent<TextMeshPro>().text=Temp0.ToString()+ " °";
            TempActuelle=0;
            PlayerPrefs.SetInt("Temper",0);
            Ttemp.GetComponent<TextMeshPro>().color=couleurbase;
        
    }
    public void Temperature1()
    {
         Debug.Log("F2");
            if(PlayerPrefs.GetInt("Smoke")!=2)
            {
                 //Ttemp.GetComponent<TextMeshPro>().text=Temp1.ToString()+ " °";
            TempActuelle=180;
            PlayerPrefs.SetInt("Temper",180);
            Ttemp.GetComponent<TextMeshPro>().color=couleurbase;
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
            Ttemp.GetComponent<TextMeshPro>().color=couleurbase;
            }
        
    }
    public void Temperature3()
    {
         Debug.Log("F4");
        if(PlayerPrefs.GetInt("Smoke")!=2)
            {
        //Ttemp.GetComponent<TextMeshPro>().text=Temp3.ToString()+ " °";
            TempActuelle=480;
            PlayerPrefs.SetInt("Temper",480);
            Ttemp.GetComponent<TextMeshPro>().color=couleurchaud;
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
    }
    public void Eteins()
    {
       // Debug.Log("Ok");
        SymbAllume.GetComponent<Animator>().SetInteger("All",0);
        Ttemp.SetActive(false);
    }

    IEnumerator coroutineA()
    {
        
        yield return new WaitForSeconds(2.0f);
        Please=true;
       
    }
}
