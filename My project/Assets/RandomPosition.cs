using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{

    public BoxCollider area;

    public Vector3 GenerateRandomPosition()
    {
        Vector3 size = area.size;
        Vector3 center = area.center;
        Vector3 position = new Vector3(
            center.x + Random.Range(-size.x / 2, size.x / 2),
            center.y + Random.Range(-size.y / 2, size.y / 2),
            center.z + Random.Range(-size.z / 2, size.z / 2)
        );
        return area.transform.TransformPoint(position);
    }

}
