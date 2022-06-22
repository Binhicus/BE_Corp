using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomObjet : MonoBehaviour
{
    public GameObject LeNom;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Tableau 1 est " +PlayerPrefs.GetInt("Tableau1"));
        Debug.Log("Tableau 2 est " +PlayerPrefs.GetInt("Tableau2"));
    }

    void OnMouseOver()
    {
       LeNom.SetActive(true);
    }


     void OnMouseExit()
    {
        LeNom.SetActive(false);
    }
}
