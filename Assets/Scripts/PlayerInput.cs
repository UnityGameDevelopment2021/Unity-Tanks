using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    public UnityEvent Shoot = new UnityEvent();
    public UnityEvent<Vector2> OnMoveHull = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();

    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }
    // Update is called once per frame
    void Update()
    {
        GetHullMovement();
        GetTurretMovement();
        GetShootInput();
    }

    private void GetShootInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot?.Invoke();
        }
    }

    private void GetTurretMovement()
    {
        OnMoveTurret?.Invoke(GetMousePosition());
    }

    private Vector2 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        return mouseWorldPosition;
    }

    private void GetHullMovement()
    {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnMoveHull?.Invoke(movementVector);
    }
}
