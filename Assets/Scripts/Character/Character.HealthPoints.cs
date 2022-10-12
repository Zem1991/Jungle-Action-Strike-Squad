using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Character : MonoBehaviour
{
    [Header("Health Points")]
    [SerializeField] private Resource healthPoints;
    public Resource HealthPoints { get => healthPoints; private set => healthPoints = value; }

    public bool IsDead()
    {
        return HealthPoints.CheckEmpty();
    }

    public bool TakeDamage(int amount)
    {
        Vector3 position = GetPosition();
        FeedbackController.Instance.CreateDamagePopup(position, amount, transform);
        HealthPoints.Subtract(amount, false);
        return IsDead();
    }

    public bool TakeHealing(int amount)
    {
        Vector3 position = GetPosition();
        FeedbackController.Instance.CreateHealingPopup(position, amount, transform);
        return HealthPoints.Add(amount);
    }
}
