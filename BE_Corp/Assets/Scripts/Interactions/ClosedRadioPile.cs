using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosedRadioPile : MonoBehaviour,IHasItemInteraction
{
    Button dezoom;
    List<GameObject> zonesZoom = new List<GameObject>(); //////////////////
    List<GameObject> steps = new List<GameObject>(); //////////////////
    public GameObject Piles; ///////////////////////
    public string nomItem;
    public string inventoryItemID => nomItem;
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
        PlayerPrefs.SetInt("PileDansRadio", 1);
        StartCoroutine(DelayBeforeDropAnim());
    }

    public void ItemDropAnim() //////////////
    {
        if (Camera.main.orthographicSize != 4.5f)
        {
            Instantiate(Piles, GameObject.Find("CT_Target").transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Piles, GameObject.Find("MC_Target").transform.position, Quaternion.identity);
        }

        StartCoroutine(AnimDrop());
    }

    void Awake()
    {
    }

    IEnumerator AnimDrop() /////////////////////
    {
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

        if (Camera.main.orthographicSize != 4.5f)
        {
            dezoom = GameObject.Find("Dezoom").GetComponent<Button>();
            dezoom.interactable = false;
            GameObject.Find("Pile Pivot instantiate(Clone)").transform.SetParent(GameObject.Find("Cam_table").transform);
            iTween.RotateTo(GameObject.Find("Pile Pivot instantiate(Clone)"), iTween.Hash("rotation", new Vector3(27.034f, -127.454f, 30.682f), "time", 0.5f, "delay", 0.25f));
            iTween.ScaleTo(GameObject.Find("Pile Pivot instantiate(Clone)"), iTween.Hash("scale", new Vector3(0.11976f, 0.11976f, 0.11976f), "time", 0.5f, "delay", 0.25f));
        }
        else
        {
            GameObject.Find("Pile Pivot instantiate(Clone)").transform.SetParent(Camera.main.transform);
            iTween.RotateTo(GameObject.Find("Pile Pivot instantiate(Clone)"), iTween.Hash("rotation", new Vector3(27.034f, -127.454f, 30.682f), "time", 0.5f, "delay", 0.25f));
            iTween.ScaleTo(GameObject.Find("Pile Pivot instantiate(Clone)"), iTween.Hash("scale", new Vector3(0.380006f, 0.380006f, 0.380006f), "time", 0.5f, "delay", 0.25f));
        }

        yield return new WaitForSeconds(0.85f);
        GameObject.Find("Pile Pivot instantiate(Clone)").transform.SetParent(GameObject.Find("Radio").transform);
        iTween.MoveTo(GameObject.Find("Pile Pivot instantiate(Clone)"), iTween.Hash("position", GameObject.Find("Piles Target").transform.position, "time", 0.75f, "easetype", iTween.EaseType.easeInOutSine, "delay", 1.5f));
        iTween.RotateTo(GameObject.Find("Pile Pivot instantiate(Clone)"), iTween.Hash("rotation", new Vector3(0f, 0f, 0f), "time", 0.75f, "delay", 1.5f));
        iTween.ScaleTo(GameObject.Find("Pile Pivot instantiate(Clone)"), iTween.Hash("scale", new Vector3(0.035058f, 0.035058f, 0.035058f), "time", 0.75f, "delay", 1.5f));
        Destroy(GameObject.Find("Pile Pivot instantiate(Clone)"), 3.5f);
        yield return new WaitForSeconds(3.5f);

        if (Camera.main.orthographicSize != 4.5f)
        dezoom.interactable = true;

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
    }
}
