using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CheckMethod
{
    Distance, 
    Trigger
}
public class DynamicLoad : MonoBehaviour, IClicked
{
    public Transform player;
    public CheckMethod checkMethod;
    public float loadRange;

    public string roomACharger, roomActuelle;

    public GameObject CamACharger, CamActuelle;

    //Scene state
    public bool isLoaded; //eviter de charger 2x
    public bool shouldLoad; //pour la méthode en trigger


    private void Awake() {
        
        if(GameObject.Find("Cursor") != null)
        {
            player = GameObject.Find("Cursor").transform ;
        }

    }
    void OnEnable()
    {
        //roomActuelle = SceneManager.GetActiveScene().name;

    }
    void LoadScene()
    {
        if (!isLoaded)
        {
            SceneManager.LoadSceneAsync(roomACharger, LoadSceneMode.Additive); // le nom du game object "Part n+1" doit être identique à celui de la scène à charger
            isLoaded = true;
        }
    }

    void UnloadScene()
    {
        if (isLoaded)
        {
            SceneManager.UnloadSceneAsync(roomActuelle);
            isLoaded = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (checkMethod == CheckMethod.Distance)
        {
            DistanceCheck();
        }
        else if (checkMethod == CheckMethod.Trigger)
        {
            TriggerCheck();
        }
    }
//method Distance
    void DistanceCheck()
    {
        if(Vector3.Distance(player.position, transform.position) < loadRange)
        {
            LoadScene();
        }
        else
        {
            UnloadScene();
        }
    }

  

 //method Trigger
    void TriggerCheck()
    {
        if (shouldLoad)
        {
            LoadScene();
        }
        else
        {
            UnloadScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            shouldLoad = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            shouldLoad = false;
        }
    }

    public void OnClickAction()
    {
        CamACharger.SetActive(true);
        CamActuelle.SetActive(false);
        UnloadScene();
        LoadScene();
    }
}
