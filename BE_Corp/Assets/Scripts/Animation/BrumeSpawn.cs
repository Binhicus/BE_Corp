using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrumeSpawn : MonoBehaviour
{
    public ParticleSystem brume;

    [Range(0, 1)]
    public float lifetime;
    void Start()
    {
        Invoke("EmitParticles", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartPtcle()
    {
        brume.Stop();
        Invoke("EmitParticles", 0.01f);
    }

    public void EmitParticles()
    {
        brume.Play();
        Invoke("RestartPtcle", lifetime);
    }
}
