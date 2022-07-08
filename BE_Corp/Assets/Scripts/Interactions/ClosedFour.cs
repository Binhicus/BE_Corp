using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedFour : MonoBehaviour,IHasItemInteraction
{
    List<GameObject> zonesZoom = new List<GameObject>(); //////////////////
    List<GameObject> steps = new List<GameObject>(); //////////////////
    public GameObject Gâteau; ///////////////////////
    public string nomItem;
    public string inventoryItemID => nomItem;
    public AudioSource unlocked;
    public GameObject PorteFour;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoItemInteraction()
    {
        StartCoroutine(DelayBeforeDropAnim());
    }

    public void ItemDropAnim() //////////////
    {
        iTween.RotateTo(GameObject.Find("Porte_Four"), iTween.Hash("rotation", new Vector3(47.891f, -179.164f, -0.867f), "time", 0.75f));
        Instantiate(Gâteau, GameObject.Find("MC_Target").transform.position, Quaternion.identity);
        StartCoroutine(AnimDrop());
    }

    void Awake()
    {
    }

    IEnumerator AnimDrop() /////////////////////
    {
        GameObject.Find("Pie Pivot instantiate(Clone)").transform.SetParent(Camera.main.transform);

        foreach (GameObject indiceZone in GameObject.FindGameObjectsWithTag("Indice Zone"))
        {
            zonesZoom.Add(indiceZone);
        }

        for (int i = 0; i < zonesZoom.Count; i++)
        {
            zonesZoom[i].GetComponent<Collider>().enabled = false;
        }

        foreach (GameObject _steps in GameObject.FindGameObjectsWithTag("Steps"))
        {
            if (_steps.GetComponent<Collider>().enabled)
            {
                steps.Add(_steps);
            }
        }

        for (int i = 0; i < steps.Count; i++)
        {
            steps[i].GetComponent<BoxCollider>().center = new Vector3(steps[i].GetComponent<BoxCollider>().center.x, steps[i].GetComponent<BoxCollider>().center.y, steps[i].GetComponent<BoxCollider>().center.z - 10f);
        }

        //CursorController.Instance.BoolFalseSetter();
        iTween.ScaleTo(GameObject.Find("Pie Pivot instantiate(Clone)"), iTween.Hash("scale", new Vector3(0.4405287f, 0.4405287f, 0.4405287f), "time", 0.5f, "delay", 0.25f));
        yield return new WaitForSeconds(1.5f);
        GameObject.Find("Pie Pivot instantiate(Clone)").transform.SetParent(GameObject.Find("Collider_Four").transform);
        iTween.MoveTo(GameObject.Find("Pie Pivot instantiate(Clone)"), iTween.Hash("position", GameObject.Find("Pie Target").transform.position, "time", 1.5f, "easetype", iTween.EaseType.easeInOutSine, "delay", 3f));
        iTween.RotateTo(GameObject.Find("Pie Pivot instantiate(Clone)"), iTween.Hash("rotation", new Vector3(0f, 0f, 0f), "time", 0.75f, "delay", 3f));
        iTween.ScaleTo(GameObject.Find("Pie Pivot instantiate(Clone)"), iTween.Hash("scale", new Vector3(0.2349997f, 0.1377073f, 0.4049899f), "time", 0.75f, "delay", 3f));
        iTween.RotateTo(GameObject.Find("Porte_Four"), iTween.Hash("rotation", new Vector3(-0.492f, -178.617f, 0.374f), "time", 0.75f, "delay", 3f));
        Destroy(GameObject.Find("Pie Pivot instantiate(Clone)"), 6f);
        yield return new WaitForSeconds(4.5f);
        //CursorController.Instance.BoolTrueSetter();

        for (int i = 0; i < zonesZoom.Count; i++)
        {
            zonesZoom[i].GetComponent<Collider>().enabled = true;
        }

        for (int i = 0; i < steps.Count; i++)
        {
            steps[i].GetComponent<BoxCollider>().center = new Vector3(steps[i].GetComponent<BoxCollider>().center.x, steps[i].GetComponent<BoxCollider>().center.y, steps[i].GetComponent<BoxCollider>().center.z + 10f);
        }
    }

    IEnumerator DelayBeforeDropAnim()
    {
        yield return new WaitForSeconds(4f);
        PlayerPrefs.SetInt("Four", 1);
        PorteFour.GetComponent<Animator>().SetTrigger("Ouvre");
    }
}
