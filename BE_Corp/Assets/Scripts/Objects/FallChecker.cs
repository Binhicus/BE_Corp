using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallChecker : MonoBehaviour
{
    public Collider checker;
    public VaseSwitch vaseSwitch;
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        checker = gameObject.GetComponent<BoxCollider>();
        vaseSwitch = GameObject.Find("Switch").GetComponent<VaseSwitch>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vase")
        {
            vaseSwitch.Destroyed();
            key.SetActive(true);
        }
    }

    private void OnEnable()
    {
        key = GameObject.Find("Clé");
        key.SetActive(false);
    }
}
