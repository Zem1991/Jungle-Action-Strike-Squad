using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class MouseUtils
{
    public static Vector3 GetMouseWorldPosition(float planeNormal = 0)
    {
        return GetMouseWorldPosition(Input.mousePosition, Camera.main, planeNormal);
    }

    public static Vector3 GetMouseWorldPosition(Vector3 screenPosition, Camera worldCamera, float planeNormal = 0)
    {
        Ray ray = worldCamera.ScreenPointToRay(screenPosition);
        Plane plane = new Plane(Vector3.up, planeNormal);
        bool hasRaycast = plane.Raycast(ray, out float enter);
        //if (hasRaycast)
        //{
        //    WorldPosition = ray.GetPoint(enter);
        //    GridPosition = TilemapHelper.GetGridPosition(WorldPosition);
        //    ValidPosition = LevelHelper.IsInside(GridPosition);
        //}
        return ray.GetPoint(enter);
    }

    public static Vector3 GetDirToMouse(Vector3 fromPosition, float planeNormal = 0)
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition(planeNormal);
        return (mouseWorldPosition - fromPosition).normalized;
    }

    // Is Mouse over a UI Element? Used for ignoring World clicks through UI
    public static bool IsPointerOverUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }
        else
        {
            PointerEventData pe = new PointerEventData(EventSystem.current);
            pe.position = Input.mousePosition;
            List<RaycastResult> hits = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pe, hits);
            return hits.Count > 0;
        }
    }
}
