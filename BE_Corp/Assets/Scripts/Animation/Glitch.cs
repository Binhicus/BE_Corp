using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
    private Material material;
    public float time;
    public bool Bug;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;

        StartCoroutine(GlitchRoutine());
    }

    private IEnumerator GlitchRoutine()
    {
        if(Bug)
        {

        
        while(true)
        {
            material.SetFloat("_GlitchStrength", -0.20f);
            material.SetFloat("_ScanlineOffset", 0.0f);
            time=Random.Range(0.3f,0.6f);
            yield return new WaitForSeconds(time);

            material.SetFloat("_GlitchStrength", 0.15f);
            material.SetFloat("_ScanlineOffset", 0.5f);
            time=Random.Range(0.3f,0.6f);
            yield return new WaitForSeconds(time);

            material.SetFloat("_GlitchStrength", 0.0f);
            material.SetFloat("_ScanlineOffset", 0.0f);
            time=Random.Range(0.1f,0.6f);
            yield return new WaitForSeconds(time);

            material.SetFloat("_GlitchStrength", 0.1f);
            material.SetFloat("_ScanlineOffset", 0.5f);
            time=Random.Range(0.1f,0.6f);
            yield return new WaitForSeconds(time);

            material.SetFloat("_GlitchStrength", 0.2f);
            material.SetFloat("_ScanlineOffset", 0.0f);
            time=Random.Range(0.1f,0.6f);
            yield return new WaitForSeconds(time);

            material.SetFloat("_GlitchStrength", -0.15f);
            material.SetFloat("_ScanlineOffset", 0.5f);
            time=Random.Range(0.1f,0.6f);
            yield return new WaitForSeconds(time);

            material.SetFloat("_GlitchStrength", 0.0f);
            material.SetFloat("_ScanlineOffset", 0.0f);
            time=Random.Range(0.1f,0.6f);
            yield return new WaitForSeconds(time);

            material.SetFloat("_GlitchStrength", 0.1f);
            material.SetFloat("_ScanlineOffset", 0.5f);
            time=Random.Range(0.1f,0.6f);
            yield return new WaitForSeconds(time);
        }

        }
    }
}
