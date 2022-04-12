using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fade : MonoBehaviour
{
   
    public UnityEvent OnSwitch;
    public GameObject[] Panel;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Panel").SetActive(true);
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        GameObject.Find("Panel").SetActive(true);
    }
    public void FadeOut()
    {
        

    }
}
