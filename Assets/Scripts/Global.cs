using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    public static Global global;

    public float cameraZoom;
    public Canvas mainCanvas;
    public Camera mainCamera;

    public GameObject selectedFleet;
    public GameObject selectedPlanet;


    private void Awake()
    {
        global = this;
        DontDestroyOnLoad(global);
    }
}
