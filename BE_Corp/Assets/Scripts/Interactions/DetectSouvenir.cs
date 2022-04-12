using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSouvenir : MonoBehaviour
{
    public GameObject BoutonSouv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player")
        {
            BoutonSouv.SetActive(true);
            BoutonSouv.GetComponent<Animator>().SetTrigger("Choix");
        }
    }
}
