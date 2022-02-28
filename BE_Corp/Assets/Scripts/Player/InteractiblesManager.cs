using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class InteractiblesManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> interactibles;

    public List<Transform> Interactibles
    {
        get => interactibles;
    }

    private Camera mainCamera;
    
 
    public static Action<Transform> AddToInteractiblesEvent;
    public static Action<Transform> RemoveFromInteractiblesEvent;

    private void Awake()
    {
        AddToInteractiblesEvent += AddToListOfInteratibles;
        RemoveFromInteractiblesEvent += RemoveFromListOfInteractibles;
    }

    private void AddToListOfInteratibles(Transform transformToAddToList)
    {
        interactibles.Add(transformToAddToList);
    }

    private void RemoveFromListOfInteractibles(Transform transformToRemoveFromList)
    {
        interactibles.Remove(transformToRemoveFromList);
    }


    void Start()
    {
        mainCamera = Camera.main;
        AllChildrenWorldToScreenPoint();
    }

    void AllChildrenWorldToScreenPoint()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            transform.GetChild(i).position = mainCamera.WorldToScreenPoint(transform.GetChild(i).position);
            transform.GetChild(i).localScale = Vector3.one * 100;
        }


    }
}
