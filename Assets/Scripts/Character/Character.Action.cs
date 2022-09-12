using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Action")]
    [SerializeField] private Command action;
    public Command Action { get => action; private set => action = value; }

    public void SetAction(Command action)
    {
        Action = action;
    }
}
