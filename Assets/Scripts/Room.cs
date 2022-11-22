using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject roomObject;

    public List<WayPoint> walkPoints = new List<WayPoint>();

    public bool isOpened;

    public WayPoint GetRandomFreeWalkPoint()
    {
        bool hasFree = false;
        foreach (var item in walkPoints)
        {
            if (item.isFree)
            {
                hasFree = true;
                break;
            }
        }

        if (!hasFree)
            return null;
        
        WayPoint selected = walkPoints[Random.Range(0, walkPoints.Capacity)];
        while (selected.isFree == false)
        {
            selected = walkPoints[Random.Range(0, walkPoints.Capacity)];
            break;
        }

        return selected;
    }
}

[System.Serializable]
public class WayPoint
{
    public Transform position;
    public bool isFree;
}