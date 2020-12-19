using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public float cameraDistanceMax;
    public float cameraDistanceMin;
    private float cameraDistance;
    public float scrollSpeed;

    private Vector3 dragOrigin;
    public GameObject background;
    public float backgroundZ;

    private new Camera camera;

    private void Start()
    {
        cameraDistance = gameObject.transform.position.z;
        camera = gameObject.GetComponent<Camera>();
        backgroundZ = background.transform.position.z;
    }

    void LateUpdate()
    {
        CheckMouseDrag();
        CheckMouseScroll();
    }

    private void CheckMouseScroll()
    {
        cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, cameraDistance);
    }
    private void CheckMouseDrag()
    {
        // for this system I used the excellent tutorial found here: https://pressstart.vip/tutorials/2018/11/9/78/perspective-camera-panning.html
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = GetWorldPosition(backgroundZ);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = dragOrigin - GetWorldPosition(backgroundZ);
            camera.transform.position += direction;
        }
    }

    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = camera.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }
}
