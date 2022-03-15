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
    bool hitting = false;
    // Start is called before the first frame update
    void Awake()
    {
        ball = gameObject.GetComponent<SphereCollider>();
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
        rb.AddForce(allant, hauteur, 0, ForceMode.Impulse);
       // rb.AddForce(Vector3.right);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MurTrigger")
        {
            hitting = true;
            Consequence();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MurTrigger")
        {
            hitting = false;
        }
    }*/
    public void Consequence()
    {      
       shaker.Shaker();
       vaseSwitch.KicksCount();
       Debug.Log("ouille ouille je suis le mur trigger et j'ai mal" + gameObject);
    }
}
