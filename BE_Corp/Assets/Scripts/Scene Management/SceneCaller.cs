using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ACharger{
    Une,
    Deux
}

public enum ADecharger{
    Une,
    Deux
}
public class SceneCaller : MonoBehaviour
{
    public KeyCode touche;
    public ACharger aCharger;
    public ADecharger aDecharger;
    public string sceneACharger;
    public string scene2ACharger;

    public string sceneADecharger;
    public string scene2ADecharger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(touche))
        {
            LoadScene();
            UnloadScene();
        }
    }

    void LoadScene()
    {
        if (aCharger == ACharger.Une)
        {
            SceneManager.LoadSceneAsync(sceneACharger, LoadSceneMode.Additive);
        }
        else if (aCharger == ACharger.Deux)
        {
            SceneManager.LoadSceneAsync(sceneACharger, LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(scene2ACharger, LoadSceneMode.Additive);
        }
    }

    void UnloadScene()
    {
        if (aDecharger == ADecharger.Une)
        {
            SceneManager.UnloadSceneAsync(sceneADecharger);
        }
        else if (aDecharger == ADecharger.Deux)
        {
            SceneManager.UnloadSceneAsync(sceneADecharger);
            SceneManager.UnloadSceneAsync(scene2ADecharger);
        }
    }
}

