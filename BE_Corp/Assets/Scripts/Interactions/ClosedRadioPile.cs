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
        StartCoroutine(DelayBeforeDropAnim());
    }

    public void ItemDropAnim() //////////////
    {
        if (Camera.main.orthographicSize != 4.5f)
        {
            Instantiate(Piles, GameObject.Find("CT_Target").transform.position, Quaternion.identity);
            Piles.transform.GetChild(0).GetComponent<Collider>().enabled = false;
            Piles.transform.GetChild(0).GetComponent<NomObjet>().enabled = false;
            Piles.transform.GetChild(0).transform.GetChild(0).GetComponent<Collider>().enabled = false;
            Piles.transform.GetChild(1).gameObject.active = false;
        }
        else
        {
            Instantiate(Piles, GameObject.Find("MC_Target").transform.position, Quaternion.identity);
            Piles.transform.GetChild(0).GetComponent<Collider>().enabled = false;
            Piles.transform.GetChild(0).GetComponent<NomObjet>().enabled = false;
            Piles.transform.GetChild(0).transform.GetChild(0).GetComponent<Collider>().enabled = false;
            Piles.transform.GetChild(1).gameObject.active = false;
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
            steps[i].GetComponent<Collider>().enabled = false;
        }

        if (Camera.main.orthographicSize != 4.5f)
        {
            dezoom = GameObject.Find("Dezoom").GetComponent<Button>();
            dezoom.interactable = false;
            GameObject.Find("Pile Pivot(Clone)").transform.SetParent(GameObject.Find("Cam_table").transform);
            iTween.RotateTo(GameObject.Find("Pile Pivot(Clone)"), iTween.Hash("rotation", new Vector3(27.034f, -127.454f, 30.682f), "time", 1f, "delay", 0.5f));
            iTween.ScaleTo(GameObject.Find("Pile Pivot(Clone)"), iTween.Hash("scale", new Vector3(0.11976f, 0.11976f, 0.11976f), "time", 0.5f, "delay", 0.5f));
        }
        else
        {
            GameObject.Find("Pile Pivot(Clone)").transform.SetParent(Camera.main.transform);
            iTween.RotateTo(GameObject.Find("Pile Pivot(Clone)"), iTween.Hash("rotation", new Vector3(27.034f, -127.454f, 30.682f), "time", 1f, "delay", 0.5f));
            iTween.ScaleTo(GameObject.Find("Pile Pivot(Clone)"), iTween.Hash("scale", new Vector3(0.380006f, 0.380006f, 0.380006f), "time", 0.5f, "delay", 0.5f));
        }

        yield return new WaitForSeconds(2f);
        GameObject.Find("Pile Pivot(Clone)").transform.SetParent(GameObject.Find("Radio").transform);
        iTween.MoveTo(GameObject.Find("Pile Pivot(Clone)"), iTween.Hash("position", GameObject.Find("Piles Target").transform.position, "time", 1.5f, "easetype", iTween.EaseType.easeInOutSine, "delay", 2f));
        iTween.RotateTo(GameObject.Find("Pile Pivot(Clone)"), iTween.Hash("rotation", new Vector3(0f, 0f, 0f), "time", 1f, "delay", 2f));
        iTween.ScaleTo(GameObject.Find("Pile Pivot(Clone)"), iTween.Hash("scale", new Vector3(0.035058f, 0.035058f, 0.035058f), "time", 1f, "delay", 2f));
        Destroy(GameObject.Find("Pile Pivot(Clone)"), 4f);
        yield return new WaitForSeconds(4f);

        if (Camera.main.orthographicSize != 4.5f)
        dezoom.interactable = true;

        for (int i = 0; i < zonesZoom.Count; i++)
        {
            zonesZoom[i].GetComponent<Collider>().enabled = true;
        }

        for (int i = 0; i < steps.Count; i++)
        {
            steps[i].GetComponent<Collider>().enabled = true;
        }
    }

    IEnumerator DelayBeforeDropAnim()
    {
        yield return new WaitForSeconds(6f);
        PlayerPrefs.SetInt("PileDansRadio", 1);
    }
}
