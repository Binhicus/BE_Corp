using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonAllume : MonoBehaviour
{
    public GameObject SymbAllume;
    public bool estAllume;
    public GameObject Barre;
    public GameObject TempFour;
    public GameObject FlecheD1;public GameObject FlecheD2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        if(!estAllume)
        {
            SymbAllume.GetComponent<Animator>().SetInteger("All",1);
            Barre.GetComponent<Animator>().SetInteger("Cran",1);
            TempFour.SetActive(true);
            this.gameObject.SetActive(false);
            FlecheD1.SetActive(true);
            FlecheD2.SetActive(true);
        }
    }
}
