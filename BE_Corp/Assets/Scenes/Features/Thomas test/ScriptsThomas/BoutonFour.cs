using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoutonFour : MonoBehaviour
{
    public bool dedans;
    public Transform Antenne;
    public float TowerAngle=-1f;
    public float TowerSpeed;
    public bool Maintiens;

     private Vector3 startPosition;
     private bool gagne;

     public bool pourAllumerFour;
     public GameObject SymboleAllumerFour;

     public GameObject ValeurFour;
     public int Temperature;

     public bool VasyGros;

     public BoutonFour BoutonFourG;

    public Vector3 rotationo;
    // Start is called before the first frame update
    void Start()
    {
       Temperature=0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        ValeurFour.GetComponent<TextMeshPro>().text=Temperature.ToString();

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

        if(pourAllumerFour==true&&TowerAngle<-0.1)
        {
           // SymboleAllumerFour.SetActive(true);
            ValeurFour.GetComponent<TextMeshPro>().enabled=true;
            VasyGros=true;
        }
        if(pourAllumerFour==true&&TowerAngle>-0.1)
        {
           // SymboleAllumerFour.SetActive(false);
            ValeurFour.GetComponent<TextMeshPro>().enabled=false;
            VasyGros=false;
        }

        if(pourAllumerFour==false&&TowerAngle<-0.1f&&TowerAngle>-0.2f&&BoutonFourG.VasyGros)
        {
            Temperature=50;
            ValeurFour.GetComponent<TextMeshPro>().color=new Color(162,255,181,255);
        }

        if(pourAllumerFour==false&&TowerAngle<-0.21f&&TowerAngle>-0.31f&&BoutonFourG.VasyGros)
        {
            Temperature=100;
            ValeurFour.GetComponent<TextMeshPro>().color=new Color(162,255,181,255);
        }
        if(pourAllumerFour==false&&TowerAngle<-0.41f&&TowerAngle>-0.51f&&BoutonFourG.VasyGros)
        {
            Temperature=150;
            ValeurFour.GetComponent<TextMeshPro>().color=new Color(162,255,181,255);
        }
        if(pourAllumerFour==false&&TowerAngle<-0.61f&&TowerAngle>-0.71f&&BoutonFourG.VasyGros)
        {
            Temperature=200;
            ValeurFour.GetComponent<TextMeshPro>().color=new Color(162,255,181,255);
        }
        if(pourAllumerFour==false&&TowerAngle<-0.72f&&TowerAngle>-0.82f&&BoutonFourG.VasyGros)
        {
            Temperature=300;
            ValeurFour.GetComponent<TextMeshPro>().color=Color.red;
        }
        if(pourAllumerFour==false&&TowerAngle<-1&&BoutonFourG.VasyGros)
        {
            TowerAngle=0;
            Temperature=0;
            ValeurFour.GetComponent<TextMeshPro>().color=new Color(162,255,181,255);
        }
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
    //TowerAngle += Input.GetAxis("Mouse X") * TowerSpeed * Time.deltaTime;

   // Antenne.transform.rotation = Quaternion.Euler(0,0,(TowerAngle*-10));    
   transform.Rotate(0,0,1);
}


}


