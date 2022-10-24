using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRotator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Vector3 eulers = new Vector3(0, 90, 0);
    [SerializeField] private float speed = 1.5F;

    private void Update()
    {
        Vector3 eulersSpeedDelta = eulers * speed * Time.deltaTime;
        transform.Rotate(eulersSpeedDelta, Space.Self);
    }
}
