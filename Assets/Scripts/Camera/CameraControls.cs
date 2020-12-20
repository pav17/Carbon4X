using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public float cameraZoomMax;
    public float cameraZoomMin;
    private float cameraZoom;
    public float scrollSpeed;

    private Vector3 dragOrigin;
    public GameObject background;
    public float backgroundZ;

    private new Camera camera;

    private void Start()
    {
        cameraZoom = 5.0f;
        Global.global.cameraZoom = cameraZoom;
        camera = gameObject.GetComponent<Camera>();
        Global.global.mainCamera = camera;
        backgroundZ = background.transform.position.z;
    }

    void Update()
    {
        CheckMouseDrag();
        CheckMouseScroll();
    }

    private void CheckMouseScroll()
    {
        cameraZoom -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cameraZoom = Mathf.Clamp(cameraZoom, cameraZoomMin, cameraZoomMax);

        Global.global.cameraZoom = cameraZoom;
        camera.orthographicSize = cameraZoom;
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, cameraDistance);
    }
    private void CheckMouseDrag()
    {
        // for this system I used the excellent tutorial found here: https://pressstart.vip/tutorials/2018/11/9/78/perspective-camera-panning.html
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = camera.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = dragOrigin - camera.ScreenToWorldPoint(Input.mousePosition);
            camera.transform.position += direction;
        }
    }
}
