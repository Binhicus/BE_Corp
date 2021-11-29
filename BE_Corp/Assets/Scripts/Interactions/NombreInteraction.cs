using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NombreInteraction : MonoBehaviour
{
    public int NbreInteractionTotale;
    public int NbreInteractionActuelle;
    public GameObject Papillon3;
    public GameObject Papillon2;
    public GameObject Papillon1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    if(NbreInteractionTotale==3){
        
        if(NbreInteractionActuelle==3)
        {
            Papillon1.SetActive(true);
            Papillon2.SetActive(true);
            Papillon3.SetActive(true);
        }

        if(NbreInteractionActuelle==2)
        {
            Papillon1.SetActive(true);
            Papillon2.SetActive(true);
            Papillon3.SetActive(false);
        }

        if(NbreInteractionActuelle==1)
        {
            Papillon1.SetActive(true);
            Papillon2.SetActive(false);
            Papillon3.SetActive(false);
        }
        if(NbreInteractionActuelle==0)
        {
            Papillon1.SetActive(false);
            Papillon2.SetActive(false);
            Papillon3.SetActive(false);
        }
    }

    }

    public void PerdInteraction()
    {
        if(NbreInteractionActuelle>0)
        {
            NbreInteractionActuelle-=1;
        }
    }
}
