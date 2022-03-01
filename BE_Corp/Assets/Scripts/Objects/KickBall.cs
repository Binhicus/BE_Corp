using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBall : MonoBehaviour
{
    public float hauteur = 1.0f;
    public float allant = 3.0f;
    public Rigidbody rb;
    public Collider ball;
    public VaseSwitch vaseSwitch;
    public SplCameraShake shaker;
    // Start is called before the first frame update
    void Awake()
    {
        ball = gameObject.GetComponentInChildren<Collider>();
        shaker = GameObject.Find("CameraShaker").GetComponent<SplCameraShake>();
        rb = GetComponent<Rigidbody>();
        vaseSwitch = GameObject.Find("Switch").GetComponent<VaseSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kicked()
    {
        rb.AddForce(0, hauteur, allant, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MurTrigger")
        {
            shaker.Shaker();
            vaseSwitch.KicksCount();

        }
    }

    public void Consequence()
    {

    }
}
