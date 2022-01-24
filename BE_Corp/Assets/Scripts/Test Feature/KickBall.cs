using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBall : MonoBehaviour
{
    public float hauteur = 1.0f;
    public float allant = 3.0f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kicked()
    {
        rb.AddForce(0, hauteur, allant, ForceMode.Impulse);
    } 
}
