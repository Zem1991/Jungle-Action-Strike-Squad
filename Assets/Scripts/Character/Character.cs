using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public partial class Character : MonoBehaviour
{
    //[Header("Character")]
    //[SerializeField] private Weapon weapon;
    //public Weapon Weapon { get => weapon; private set => weapon = value; }

    private void Awake()
    {
        Inventory = GetComponent<Inventory>();
        SkillSet = GetComponent<SkillSet>();
    }

    private void Start()
    {
        RefreshCommands();
        RefreshGridPosition();
    }

    //private void Update()
    //{
    //    UpdateCommand();
    //    UpdateNavigation();
    //}

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetDirection()
    {
        return transform.forward;
    }
}
