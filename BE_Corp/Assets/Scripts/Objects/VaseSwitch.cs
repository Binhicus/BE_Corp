using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VaseSwitch : ClickableObject
{
    [Header("   Objets")]
    public GameObject vase, vasePivot;
    public GameObject brokenTransform;
    public GameObject brokenVase;
    
    [Header("   Anims")]
    public Animator vaseAnimator;
    
    [Header("   Valeurs Chiffrées")]
    public int kicks;
    public float attente = 0.6f;

    [Header("   Sons")]
    public AudioSource casse;
    public AudioSource roll;
    // Start is called before the first frame update
    void Start()
    {
        kicks = 0;
        brokenTransform = GameObject.Find("brokenTransform");
        vase = GameObject.Find("vase");
        casse = GameObject.Find("casse").GetComponent<AudioSource>();
        roll = GameObject.Find("roll").GetComponent<AudioSource>();
        if (vase != null)
        {
            vaseAnimator = gameObject.GetComponentInChildren<Animator>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (kicks == 3)
        {
            StartCoroutine(Desactivate());
        }*/

        brokenTransform.transform.position = vasePivot.transform.position;
        brokenTransform.transform.rotation = vasePivot.transform.rotation;
    }

    public void KicksCount() // pour l'instant assigné à un bouton 
    {
        ++kicks;
        //roll.Play();
        vaseAnimator.SetTrigger("hop");
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
        casse.Play();
        Jauge.Instance.current += 10;
        vase.SetActive(false);
        brokenVase.SetActive(true);
        PlayerPrefs.SetInt("VaseAndKey", 1);
    }
}
