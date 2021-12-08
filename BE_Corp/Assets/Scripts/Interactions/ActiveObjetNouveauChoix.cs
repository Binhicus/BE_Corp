using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjetNouveauChoix : MonoBehaviour
{
    public float nombreObjetRequis;

    public Pickup pickup1;
    public Pickup pickup2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nombreObjetRequis==1&&pickup1.InteragitAvecObjet==true)
        {
            this.GetComponent<BoxCollider>().enabled=true;

        }

        if(nombreObjetRequis==2&&pickup1.InteragitAvecObjet==true&&pickup2.InteragitAvecObjet==true)
        {
            this.GetComponent<BoxCollider>().enabled=true;

        }
    }
}
