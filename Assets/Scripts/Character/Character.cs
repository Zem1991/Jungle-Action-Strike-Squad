using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public abstract partial class Character : MonoBehaviour
{
    [Header("Character Data")]
    [SerializeField] protected CharacterData characterData;
    public CharacterData CharacterData { get => characterData; private set => characterData = value; }

    public void Initialize(CharacterData characterData)
    {
        CharacterData = characterData;

        HealthPoints = new Resource(characterData.HealthPointsStart);
        ActionPoints = new Resource(characterData.ActionPointsStart);

        SkillSet = new SkillSet(characterData);

        //Inventory = new Inventory(characterData);
        Inventory = GetComponent<Inventory>();
        InventoryCreatorHelper.FullInventory(this, characterData);
    }

    //private void Awake()
    //{
    //    HealthPoints = new Resource(characterData.HealthPointsStart);
    //    ActionPoints = new Resource(characterData.ActionPointsStart);
    //    SkillSet = new SkillSet(characterData);
    //    //Inventory = new Inventory(characterData);
    //    Inventory = GetComponent<Inventory>();
    //}

    private void Start()
    {
        //TODO: This is here for testing purposes
        Initialize(CharacterData);

        RefreshCommands();
        RefreshGridPosition();
    }

    public Vector3 GetPosition() => transform.position;
    public Vector3 GetDirection() => transform.forward;

    public void RotateTo(Vector3 position) => RotationHelper.RotateTo(this, position);
    public void RotateAt(Vector3 direction) => RotationHelper.RotateAt(this, direction);

    public void MoveTo(Vector3 position) => MovementHelper.MoveTo(this, position);
    public void MoveAt(Vector3 direction) => MovementHelper.MoveAt(this, direction);
}
