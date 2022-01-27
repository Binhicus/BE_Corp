using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VaseSwitch : MonoBehaviour
{
    public int kicks;
    public GameObject vase;
    public GameObject brokenTransform;
    public GameObject brokenVase;
    public Animator vaseAnimator;
    public float attente = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        kicks = 0;
        brokenTransform = GameObject.Find("brokenTransform");
        vase = GameObject.Find("vase_Pivot");
        if (vase != null)
        {
            vaseAnimator = vase.GetComponent<Animator>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kicks == 3)
        {
            StartCoroutine(Desactivate());
        }
        /*if (brokenVase)
        {
            brokenTransform.transform.position = vase.transform.position;
            brokenTransform.transform.rotation = vase.transform.rotation;
        }*/
    }

    public void KicksCount() // pour l'instant assigné à un bouton 
    {
        ++kicks;
    }

    IEnumerator Desactivate()
    {

        yield return new WaitForSeconds(attente);
        brokenTransform.transform.position = vase.transform.position;
        brokenTransform.transform.rotation = vase.transform.rotation;//vaseAnimator.enabled = false;
        Destroyed();
    }

    public void Destroyed()
    {
        vase.SetActive(false);
        brokenVase.SetActive(true);
    }
}
