using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoueChoix : MonoBehaviour
{
    public GameObject BoutonChoix1;
    public GameObject BoutonChoix2;
    public GameObject BoutonChoix3;
    public GameObject BoutonChoix4;

    public Color couleurBouton1;
    public Color couleurBouton2;
    public Color couleurBouton3;
    public Color couleurBouton4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SurChoix1()
    {
        BoutonChoix1.GetComponent<Image>().color=couleurBouton1;
    }
    public void SurChoix2()
    {
        BoutonChoix2.GetComponent<Image>().color=couleurBouton2;
    }
    public void SurChoix3()
    {
        BoutonChoix3.GetComponent<Image>().color=couleurBouton3;
    }
    public void SurChoix4()
    {
        BoutonChoix4.GetComponent<Image>().color=couleurBouton4;
    }

    public void EnleveSurChoix1()
    {
        BoutonChoix1.GetComponent<Image>().color=Color.white;
    }
    public void EnleveSurChoix2()
    {
        BoutonChoix2.GetComponent<Image>().color=Color.white;
    }
    public void EnleveSurChoix3()
    {
        BoutonChoix3.GetComponent<Image>().color=Color.white;
    }
    public void EnleveSurChoix4()
    {
        BoutonChoix4.GetComponent<Image>().color=Color.white;
    }
}
