using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParleClient : MonoBehaviour
{
    public GameObject DialogBox;
    public AudioSource Excla;
    public GameObject ButtonChoix;
    public TriggerObject triggerObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ParleClientV()
    {
        
        triggerObject.ChoixRestant-=1;
        Excla.Play();
        DialogBox.SetActive(true);
        ButtonChoix.GetComponent<Animator>().SetTrigger("Retour");
        ButtonChoix.SetActive(false);
    }
}
