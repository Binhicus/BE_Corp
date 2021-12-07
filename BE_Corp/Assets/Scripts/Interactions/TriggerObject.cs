using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public Outline outline;
    public GameObject PressE;
    public bool dedans;
    public List<GameObject>ChoixBoutons=new List<GameObject>();
    public bool Anim;
    public float ChoixRestant;
    // Start is called before the first frame update
    void Start()
    {
        ChoixRestant=ChoixBoutons.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(dedans==true&&Input.GetKeyDown(KeyCode.E))
        {
            PressE.SetActive(false);

            for (int i = 0; i < ChoixBoutons.Count; i++)
        {
            ChoixBoutons[i].SetActive(true);
            if(Anim)
            {
                ChoixBoutons[i].GetComponent<Animator>().SetTrigger("Choix");
            }
        }
        }

        if(ChoixRestant<=0) // Si le nombre de choix qu'il reste à l'objet est 0 alors on ne peut plus intéragir avec donc l'effet de surbrillance est désactiver et le " E pour intéragir " aussi 
        {
            this.GetComponent<BoxCollider>().enabled=false;
            outline.enabled=false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player")
        {
            outline.enabled=true;
            PressE.SetActive(true);
            dedans=true;
        }
    }


    private void OnTriggerExit(Collider other) {
        if(other.tag=="Player")
        {
            outline.enabled=false;
            PressE.SetActive(false);
            dedans=false;

            for (int i = 0; i < ChoixBoutons.Count; i++)
        {
             ChoixBoutons[i].GetComponent<Animator>().SetTrigger("Retour");
            ChoixBoutons[i].SetActive(false);
        }
        }
    }
}
