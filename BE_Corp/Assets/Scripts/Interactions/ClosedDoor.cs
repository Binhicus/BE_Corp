using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour, IHasItemInteraction
{
    List<GameObject> zonesZoom = new List<GameObject>(); //////////////////
    public string nomItem;
    private Animator DoorAnimator;
    private string LeaveStepName;
    public string inventoryItemID => nomItem;
    public AudioSource unlocked;
    public GameObject LeaveStep;
    public GameObject Key; ///////////////////////

    bool DoorIsOpen;

    void Awake()
    {
        //DoorAnimator = this.transform.parent.GetComponent<Animator>();
        //if (GameObject.Find(LeaveStepName) != null) LeaveStep = GameObject.Find(LeaveStepName);
        LeaveStep=GameObject.Find("LeaveStep");
    }
    /*void OnEnable()
    {
        if (PlayerPrefs.GetInt("Porte Ouverte") == 0)
        {
            LeaveStep.GetComponent<DynamicLoad>().DispStep(false);
        }
        else
        {
            LeaveStep.GetComponent<DynamicLoad>().DispStep(true);
            //DoorIsOpen = true;
            DoorAnimator.SetTrigger("Open");
        }
    }*/
    public void DoItemInteraction()
    {
        //Debug.Log("C'est ouvert merci beaucoup pour la participation");
        unlocked.Play();
        PorteOuverte();
        PasActifs();
        this.GetComponent<BoxCollider>().enabled = false;
       
    }

    public void ItemDropAnim () //////////////
    {
        Instantiate(Key, GameObject.Find("MC_Target").transform.position, Quaternion.identity);
        StartCoroutine(AnimDrop());
    }

    void PasActifs()
    {
        LeaveStep.SetActive(true);
        LeaveStep.GetComponentInParent<BoxCollider>().enabled = true;
    }

    void PorteOuverte()
    {
        this.GetComponentInParent<Animator>().SetTrigger("Door Animation");
        PlayerPrefs.SetInt("Porte Ouverte", 1);
    }

    IEnumerator AnimDrop() /////////////////////
    {
        GameObject.Find("Clef Pivot(Clone)").transform.SetParent(Camera.main.transform);

        foreach (GameObject indiceZone in GameObject.FindGameObjectsWithTag("Indice Zone"))
        {
            zonesZoom.Add(indiceZone);
        }

        for (int i = 0; i < zonesZoom.Count; i++)
        {
            zonesZoom[i].GetComponent<Collider>().enabled = false;
        }

        Destroy(GameObject.Find("PU_shine Key"));
        iTween.RotateTo(GameObject.Find("Clef Pivot(Clone)"), iTween.Hash("rotation", new Vector3(47.009f, -65.723f, 167.92f), "time", 1f, "delay", 0.5f));
        iTween.ScaleTo(GameObject.Find("Clef Pivot(Clone)"), iTween.Hash("scale", new Vector3(2.5f, 2.5f, 2.5f), "time", 0.5f, "delay", 0.5f));
        yield return new WaitForSeconds(2f);
        GameObject.Find("Clef Pivot(Clone)").transform.SetParent(GameObject.Find("Door Room").transform);
        iTween.MoveTo(GameObject.Find("Clef Pivot(Clone)"), iTween.Hash("position", GameObject.Find("Key Target").transform.position, "time", 1.5f, "easetype", iTween.EaseType.easeInOutSine, "delay", 2f));
        iTween.RotateTo(GameObject.Find("Clef Pivot(Clone)"), iTween.Hash("rotation", new Vector3(0f, -90f, 0f), "time", 1f, "delay", 2f));
        iTween.ScaleTo(GameObject.Find("Clef Pivot(Clone)"), iTween.Hash("scale", new Vector3(0.00199823268f, 0.00199823361f, 0.00281441351f), "time", 0.15f, "delay", 2f));
        Destroy(GameObject.Find("Clef Pivot(Clone)"), 4f);
        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < zonesZoom.Count; i++)
        {
            zonesZoom[i].GetComponent<Collider>().enabled = true;
        }
    }
}
