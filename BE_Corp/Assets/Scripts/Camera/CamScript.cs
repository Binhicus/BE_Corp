using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public static CamScript camInstance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (camInstance == null) camInstance = this;
        else Destroy(gameObject);

    }
}
