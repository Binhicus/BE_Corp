using EPOOutline;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlinerCloser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Outlinable>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
