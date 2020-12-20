using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionMarker : MonoBehaviour
{
    public GameObject fleetIcon;
    private RectTransform fleetIconRectTransform;
    void Start()
    {
        fleetIcon = Instantiate(Resources.Load("Prefabs/ShipIconUIElement")) as GameObject;
        fleetIcon.transform.SetParent(Global.global.mainCanvas.transform);
        //fleetIcon.GetComponent<IconClicker>().assignedFormation = gameObject;
        fleetIconRectTransform = fleetIcon.GetComponent<RectTransform>();
    }

    void Update()
    {
        UpdateIconPosition();
    }

    void UpdateIconPosition()
    {
        Vector3 IconScreenPos = Global.global.mainCamera.WorldToScreenPoint(gameObject.transform.position);
        fleetIconRectTransform.transform.position = IconScreenPos;
    }
}
