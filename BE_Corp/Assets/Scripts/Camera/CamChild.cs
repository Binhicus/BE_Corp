using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CamChild : MonoBehaviour
{
    Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Camera>().orthographicSize = mainCam.orthographicSize;
    }
}
