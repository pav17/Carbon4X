using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global global;

    public float cameraZoom;



    private void Awake()
    {
        global = this;
        DontDestroyOnLoad(global);
    }
}
