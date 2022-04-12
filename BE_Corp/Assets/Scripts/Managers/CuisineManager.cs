using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuisineManager : MonoBehaviour
{
    public GameObject Vase;
    // Start is called before the first frame update
   void Awake()
   {
       if(PlayerPrefs.GetInt("Vase")==1)
        {
            Debug.Log("Vase Cassé");
        }
        if(PlayerPrefs.GetInt("Key")==1)
        {
            
        }
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
