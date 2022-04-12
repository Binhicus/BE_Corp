using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTestInteract : MonoBehaviour, IClicked
{
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;
    public ActionWheel ActionWheelScript ;

    private void Awake() {
      //  ActionWheelScript = GameObject.Find("Action Wheel").GetComponent<ActionWheel>();
    }
    public void OnClickAction()
    {
        ActionWheelScript.ChoicesDisplay = ListInteractPossible ;
        ActionWheelScript.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
