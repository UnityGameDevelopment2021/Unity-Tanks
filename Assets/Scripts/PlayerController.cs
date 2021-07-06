using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _horizontalInput = 0f;
    private float _verticalInput = 0f;
    private Vector3 _mousePosition;
    PlayerTankMovement actionScript;
    void Start()
    {
        actionScript = GetComponent<PlayerTankMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerMovement();
        actionScript.RotationTankTurret(_mousePosition);
        actionScript.RotationTankBody(_horizontalInput);
    }

    private void FixedUpdate()
    {
        actionScript.MovePlayer(_verticalInput);
    }
    private void GetPlayerMovement()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 mousePosition3d = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Debug.Log(mousePosition3d);
        _mousePosition = new Vector3(mousePosition3d.x, mousePosition3d.y, 0);
    }
}
