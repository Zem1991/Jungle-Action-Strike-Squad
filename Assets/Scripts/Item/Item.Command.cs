using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Item : ScriptableObject
{
    [Header("Command")]
    [SerializeField] private Command command1;
    [SerializeField] private Command command2;
    public Command Command1 { get => command1; private set => command1 = value; }
    public Command Command2 { get => command2; private set => command2 = value; }
}
