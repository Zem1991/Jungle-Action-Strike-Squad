using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Projectile : MonoBehaviour
{
    //[Header("Collision")]
    private Collider colliderHit;

    private void UpdateCollision()
    {
        //TODO: check for explosions
        if (!colliderHit) return;
        Character character = colliderHit.GetComponent<Character>();
        if (character)
        {
            Damage.Apply(User, Weapon, transform.position, character);
        }
        Destroy();
    }
}
