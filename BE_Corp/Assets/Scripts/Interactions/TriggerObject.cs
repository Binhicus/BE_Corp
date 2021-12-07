using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public Outline outline;
    public GameObject PressE;
    public bool dedans;
    public List<GameObject>ChoixBoutons=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
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
            ChoixBoutons[i].SetActive(false);
        }
        }
    }
}
