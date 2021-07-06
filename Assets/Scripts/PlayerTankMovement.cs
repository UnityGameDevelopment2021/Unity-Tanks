using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankMovement : MonoBehaviour
{

    public int movementSpeed = 0;
    public int rotationSpeedHull = 0;
    public int rotationSpeedTurret = 0;

    Transform tankBody;
    Transform tankTurret;
    Rigidbody2D rigit2D;
    // Start is called before the first frame update
    void Start()
    {
        rigit2D = GetComponent<Rigidbody2D>();
        tankBody = transform.Find("Hull");
        tankTurret = transform.Find("Turret");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer(float inputValue)
    {
        rigit2D.velocity = tankBody.up * inputValue * movementSpeed;
    }

    public void RotationTankBody(float inputValue)
    {
        float rotation = -inputValue * rotationSpeedHull;
        tankBody.Rotate(Vector3.forward * rotation);
    }

    public void RotationTankTurret(Vector3 endpoint)
    {
        Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, endpoint - tankTurret.position);
        // desiredRotation = Quaternion.Euler(0, 0, desiredRotation.eulerAngles.z + 90);
        tankTurret.rotation = Quaternion.RotateTowards(tankTurret.rotation, desiredRotation, rotationSpeedTurret * Time.deltaTime);
    }
}
