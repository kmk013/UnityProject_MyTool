using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler{

    private RectTransform background;
    private RectTransform stick;

    public Vector3 normalizedTouchPos;

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 touchPosition = Input.mousePosition - background.anchoredPosition3D;
        if (Mathf.Abs(touchPosition.x) + Mathf.Abs(touchPosition.y) <= background.sizeDelta.x / 2)
            stick.anchoredPosition3D = touchPosition;
        else
            stick.anchoredPosition3D = touchPosition.normalized * (background.sizeDelta.x / 2);

        normalizedTouchPos = touchPosition.normalized;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 touchPosition = Input.mousePosition - background.anchoredPosition3D;
        if (Mathf.Abs(touchPosition.x) + Mathf.Abs(touchPosition.y) <= background.sizeDelta.x / 2)
            stick.anchoredPosition3D = touchPosition;
        else
            stick.anchoredPosition3D = touchPosition.normalized * (background.sizeDelta.x / 2);

        normalizedTouchPos = touchPosition.normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        stick.anchoredPosition = Vector2.zero;
        normalizedTouchPos = Vector3.zero;
    }

    private void Start()
    {
        background = GetComponent<RectTransform>();
        stick = transform.GetChild(0).GetComponent<RectTransform>();
    }
}
