using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CameraHolder : MonoBehaviour
{
    [Header("Awake")]
    [SerializeField] private new Camera camera;

    [Header("Setup")]
    [SerializeField] private float moveSpeed = 25F;
    [SerializeField] private float rotateSpeed = 100F;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    public float RotateSpeed { get => rotateSpeed; private set => rotateSpeed = value; }

    private void Awake()
    {
        camera = GetComponentInChildren<Camera>();
    }

    private Vector3 SnapPositionToLevelGrid(Vector3 position)
    {
        LevelGrid levelGrid = LevelController.Instance.GetLevelGrid();
        return levelGrid.SnapPosition(position);
    }

    public void Position(Vector3 position, float lerpRatio)
    {
        Vector3 myPos = transform.position;
        position = Vector3.Lerp(myPos, position, lerpRatio);
        position = SnapPositionToLevelGrid(position);
        transform.position = position;
    }

    public void Move(Vector3 input)
    {
        if (input.magnitude > 1) input.Normalize();
        Vector3 translation = input * MoveSpeed;
        translation *= Time.deltaTime;

        float currentRot = transform.eulerAngles.y;
        translation = Quaternion.AngleAxis(currentRot, Vector3.up) * translation;
        transform.Translate(translation, Space.World);

        Vector3 position = transform.position;
        transform.position = SnapPositionToLevelGrid(position);
    }

    public void Rotate(float input)
    {
        float rotation = input * RotateSpeed;
        rotation *= Time.deltaTime;

        Vector3 eulers = new Vector3(0, rotation, 0);
        transform.Rotate(eulers, Space.World);
    }

    public void Zoom(float input)
    {
        Debug.Log("TODO");
    }

    public void Look(Vector3 input)
    {
        if (input.magnitude > 1) input.Normalize();
        Debug.Log("TODO");
    }

    public void UseDefaults()
    {
        Debug.Log("TODO");
    }
}
