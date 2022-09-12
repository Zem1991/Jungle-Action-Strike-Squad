using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    private void Update()
    {
        UpdateCollision();
        UpdateLifespan();
        UpdateMovement();
    }

    private void OnDestroy()
    {
        if (OnFinish != null) OnFinish();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetDirection()
    {
        return transform.forward;
    }
}
