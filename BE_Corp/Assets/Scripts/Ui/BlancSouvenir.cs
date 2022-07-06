using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlancSouvenir : MonoBehaviour
{
    public float TempsAttendre;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Awake()
    {
         //ChargeSouvenir();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChargeSouvenir()
    {
        StartCoroutine(coroutineA());
        
    }

    IEnumerator coroutineA()
    {
        this.GetComponent<Animator>().CrossFade("Start_Fade", 0f);
        GlitchyBreak.Instance.GlitchEffectOn();
        yield return new WaitForSeconds(TempsAttendre);
        GlitchyBreak.Instance.GlitchEffectOff();
       
    }
}
