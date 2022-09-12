using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Item : MonoBehaviour
{
    private void Update()
    {
        UpdateMovement();
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
}
