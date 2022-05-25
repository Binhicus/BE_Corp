using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeMicroOnde : MonoBehaviour
{
    public GameObject Tcode;
    public static string num1;
    public static string num2;
    public static  string deuxpoints;
    public static string num3;
    public static string num4;

    public static float NumActuel;

    public bool Bout1;
    public bool Bout2;
    public bool Bout3;
    public bool Bout4;
    public bool Bout5;
    public bool Bout6;
    public bool Bout7;
    public bool Bout8;
    public bool Bout9;

    public GameObject porteMicro;

    public static bool PeutAppuyer;

    //public SpriteRenderer Bon;

    public string LeBonCode;
    //public GameObject CodeBonOuvrir;
    public AudioSource BruitMicro;
    // Start is called before the first frame update

    void Awake()
    {
        //Tcode = gameObject.AddComponent<TextMesh>();

       // Tcode.text = Time.time.ToString();

       porteMicro=GameObject.Find("Porte_Microondes");
    }
    void Start()
    {
        NumActuel=1;
        num1=0.ToString();
        num2=0.ToString();
        num3=0.ToString();
        num4=0.ToString();
        deuxpoints=":";
        PeutAppuyer=true;
    }

    // Update is called once per frame
    void Update()
    {
        Tcode.GetComponent<TextMeshPro>().text=num1+num2+deuxpoints+num3+num4;

        if(NumActuel>4)
        {
            NumActuel=1;
        }

        //Tcode.text = Time.time.ToString();

      //  Debug.Log(NumActuel);
    }

    public void Un()
    {
        if(NumActuel==1)
        {
            num1=1.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==2)
        {
            num2=1.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==3)
        {
            num3=1.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==4)
        {
            num4=1.ToString();
            StartCoroutine(coroutineA());
        }
    }
    public void Deux()
    {
        if(NumActuel==1)
        {
            num1=2.ToString();
            Debug.Log("Ba");
            StartCoroutine(coroutineA());
        }
        if(NumActuel==2)
        {
            num2=2.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==3)
        {
            num3=2.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==4)
        {
            num4=2.ToString();
            StartCoroutine(coroutineA());
        }
    }
    public void Trois()
    {
        if(NumActuel==1)
        {
            num1=3.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==2)
        {
            num2=3.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==3)
        {
            num3=3.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==4)
        {
            num4=3.ToString();
            StartCoroutine(coroutineA());
        }
    }
    public void Quatre()
    {
        if(NumActuel==1)
        {
            num1=4.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==2)
        {
            num2=4.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==3)
        {
            num3=4.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==4)
        {
            num4=4.ToString();
            StartCoroutine(coroutineA());
        }

    }
    public void Cinq()
    {
        if(NumActuel==1)
        {
            num1=5.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==2)
        {
            num2=5.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==3)
        {
            num3=5.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==4)
        {
            num4=5.ToString();
            StartCoroutine(coroutineA());
        }
    }
    public void Six()
    {
        if(NumActuel==1)
        {
            num1=6.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==2)
        {
            num2=6.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==3)
        {
            num3=6.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==4)
        {
            num4=6.ToString();
            StartCoroutine(coroutineA());
        }
    }
    public void Sept()
    {
        if(NumActuel==1)
        {
            num1=7.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==2)
        {
            num2=7.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==3)
        {
            num3=7.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==4)
        {
            num4=7.ToString();
            StartCoroutine(coroutineA());
        }
    }   
    public void Huit()
    {
        if(NumActuel==1)
        {
            num1=8.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==2)
        {
            num2=8.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==3)
        {
            num3=8.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==4)
        {
            num4=8.ToString();
            StartCoroutine(coroutineA());
        }
    }
    public void Neuf()
    {
        if(NumActuel==1)
        {
            num1=9.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==2)
        {
            num2=9.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==3)
        {
            num3=9.ToString();
            StartCoroutine(coroutineA());
        }
        if(NumActuel==4)
        {
            num4=9.ToString();
            StartCoroutine(coroutineA());
        }
    }

    private void OnMouseDown() {
        if(Bout1&&PeutAppuyer)
        {
            BruitMicro.Play();
            Un();
        }
        if(Bout2&&PeutAppuyer)
        {
            BruitMicro.Play();
            Deux();
            Debug.Log("deux");
        }
        if(Bout3&&PeutAppuyer)
        {
            BruitMicro.Play();
            Trois();
        }
        if(Bout4&&PeutAppuyer)
        {
            BruitMicro.Play();
            Quatre();
        }
        if(Bout5&&PeutAppuyer)
        {
            BruitMicro.Play();
            Cinq();
        }
        if(Bout6&&PeutAppuyer)
        {
            BruitMicro.Play();
            Six();
        }
        if(Bout7&&PeutAppuyer)
        {
            BruitMicro.Play();
            Sept();
        }
        if(Bout8&&PeutAppuyer)
        {
            BruitMicro.Play();
            Huit();
        }
        if(Bout9&&PeutAppuyer)
        {
            BruitMicro.Play();
            Neuf();
        }
    }

    public void OnMouseOver() {
        this.GetComponentInChildren<SpriteRenderer>().enabled=true;
    }

    public void OnMouseExit() {
         this.GetComponentInChildren<SpriteRenderer>().enabled=false;
    }

    IEnumerator coroutineA()
    {
        Debug.Log("+1");
        yield return new WaitForSeconds(0.1f);
        NumActuel+=1;

        if(Tcode.GetComponent<TextMeshPro>().text==LeBonCode)
        {
            gagne();
        }
       
    }

    public void gagne()
    {
        Debug.Log("OKKK");
       // CodeBonOuvrir.SetActive(true);
        PeutAppuyer=false;
        //Bon.color=new Color32(139,255,0,255);
        porteMicro.GetComponent<Animator>().SetTrigger("Ouvre");
    }
}
