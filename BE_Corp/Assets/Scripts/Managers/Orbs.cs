using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Orbs : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        this.gameObject.GetComponent<VisualEffect>().Play();
    }
}
