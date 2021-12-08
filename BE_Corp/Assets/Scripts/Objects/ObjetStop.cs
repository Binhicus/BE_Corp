using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetStop : MonoBehaviour
{
    public float temps;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<ParticleSystem>().Play();
        StartCoroutine(coroutineA());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator coroutineA()
    {
        
        yield return new WaitForSeconds(temps);
       this.gameObject.SetActive(false);
        this.GetComponent<ParticleSystem>().Stop();
    }
}
