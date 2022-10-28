using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Character : MonoBehaviour
{
    [Header("Command")]
    [SerializeField] private Command command;
    public Command Command { get => command; private set => command = value; }

    public void SetCommand(Command command)
    {
        Command = command;
    }
}
