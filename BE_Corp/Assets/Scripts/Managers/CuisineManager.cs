using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuisineManager : MonoBehaviour
{
    public GameObject radio, gateau, microOndes;
    // Start is called before the first frame update
   void OnEnable()
   {
       
   }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VaseCasse()
    {
        PlayerPrefs.SetInt("Vase",1 );
    }
     public void CleObtenue()
    {
        PlayerPrefs.SetInt("Key", 1 );
    }
}
