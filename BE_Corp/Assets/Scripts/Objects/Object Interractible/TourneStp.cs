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
        if(BoutonD&&PlayerPrefs.GetInt("Smoke")==2)
        {
            Smoke.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {


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
        if(this.transform.eulerAngles.z>69.7f&&this.transform.eulerAngles.z<144&&BoutonD&&PlayerPrefs.GetInt("Smoke")!=2)
        {
            
            Ttemp.GetComponent<TextMeshPro>().text=Temp0.ToString()+ " °";
            Ttemp.GetComponent<TextMeshPro>().color=couleurbase;
            PlayerPrefs.SetInt("Smoke",1);
        }
        if(this.transform.eulerAngles.z>144f&&this.transform.eulerAngles.z<245&&BoutonD&&PlayerPrefs.GetInt("Smoke")!=2)
        {
           
            Ttemp.GetComponent<TextMeshPro>().text=Temp1.ToString()+ " °";
            Ttemp.GetComponent<TextMeshPro>().color=couleurbase;
            PlayerPrefs.SetInt("Smoke",1);
        }
        if(this.transform.eulerAngles.z>245f&&this.transform.eulerAngles.z<340&&BoutonD&&PlayerPrefs.GetInt("Smoke")!=2)
        {
            
            Ttemp.GetComponent<TextMeshPro>().text=Temp2.ToString()+ " °";
            Ttemp.GetComponent<TextMeshPro>().color=couleurbase;
            PlayerPrefs.SetInt("Smoke",1);
        }
        if(this.transform.eulerAngles.z<75&&BoutonD&&PlayerPrefs.GetInt("Smoke")!=2)
        {
            
            Ttemp.GetComponent<TextMeshPro>().text=Temp3.ToString()+ " °";
            Ttemp.GetComponent<TextMeshPro>().color=couleurchaud;
            
             PlayerPrefs.SetInt("Smoke",2);
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
}
