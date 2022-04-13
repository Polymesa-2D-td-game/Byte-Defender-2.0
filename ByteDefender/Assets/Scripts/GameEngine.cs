using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class GameEngine
{
    public static Vector2 GetMouseWorldPosition()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return mouseWorldPosition;
    }

    public static bool IsMouseOverLayer(int layer)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);

        for (int i = 0; i < raycastResultList.Count; i++)
            if (raycastResultList[i].gameObject.layer == layer)
                return true;

        return false;
    }

    public static bool IsMouseOutsideCameraView()
    {
        var view = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        var isOutside = view.x < 0 || view.x > 1 || view.y < 0 || view.y > 1;

        return isOutside;
    }
}
