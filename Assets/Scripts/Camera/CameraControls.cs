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
    private bool dragging = false;
    public GameObject background;
    public float backgroundZ;

    private Camera camera;

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
