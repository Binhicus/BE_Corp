using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMicroR : MonoBehaviour
{
    public GameObject PorteMicroOnde;
    public GameObject ColliderMicroOnde;
    // Start is called before the first frame update
    void Start()
    {
        ColliderMicroOnde=GameObject.Find("Collider_Micro_Ondes");
        PorteMicroOnde=GameObject.Find("Porte_Micro_Onde");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnMouseDown() {
        Debug.Log("Rat");
        PorteMicroOnde.SetActive(false);
        ColliderMicroOnde.SetActive(false);
    }
}
