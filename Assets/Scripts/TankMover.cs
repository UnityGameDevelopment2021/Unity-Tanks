using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    private Vector2 movementVector;
    [SerializeField] public float hullMaxSpeed = 10f;
    [SerializeField] public float hullRotationSpeed = 1f;
    private void Awake()
    {
        rigid2D = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    private void FixedUpdate()
    {
        rigid2D.velocity = (Vector2)transform.up * movementVector.y * hullMaxSpeed * Time.deltaTime;
        rigid2D.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * hullRotationSpeed * Time.fixedDeltaTime));
    }
}
