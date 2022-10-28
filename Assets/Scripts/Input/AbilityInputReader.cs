using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityInputReader
{
    [SerializeField] private KeyCode escape = KeyCode.Escape;
    [SerializeField] private KeyCode key1 = KeyCode.Q;
    [SerializeField] private KeyCode key2 = KeyCode.E;
    [SerializeField] private KeyCode key3 = KeyCode.R;
    [SerializeField] private KeyCode key4 = KeyCode.T;
    [SerializeField] private KeyCode key5 = KeyCode.Z;
    [SerializeField] private KeyCode key6 = KeyCode.X;
    [SerializeField] private KeyCode key7 = KeyCode.C;
    [SerializeField] private KeyCode key8 = KeyCode.V;
    public KeyCode Escape { get => escape; private set => escape = value; }
    public KeyCode Key1 { get => key1; private set => key1 = value; }
    public KeyCode Key2 { get => key2; private set => key2 = value; }
    public KeyCode Key3 { get => key3; private set => key3 = value; }
    public KeyCode Key4 { get => key4; private set => key4 = value; }
    public KeyCode Key5 { get => key5; private set => key5 = value; }
    public KeyCode Key6 { get => key6; private set => key6 = value; }
    public KeyCode Key7 { get => key7; private set => key7 = value; }
    public KeyCode Key8 { get => key8; private set => key8 = value; }

    public int KeyToIndex()
    {
        if (Input.GetKeyDown(Escape)) return 0;
        if (Input.GetKeyDown(Key1)) return 1;
        if (Input.GetKeyDown(Key2)) return 2;
        if (Input.GetKeyDown(Key3)) return 3;
        if (Input.GetKeyDown(Key4)) return 4;
        if (Input.GetKeyDown(Key5)) return 5;
        if (Input.GetKeyDown(Key6)) return 6;
        if (Input.GetKeyDown(Key7)) return 7;
        if (Input.GetKeyDown(Key8)) return 8;
        return -1;
    }
}
