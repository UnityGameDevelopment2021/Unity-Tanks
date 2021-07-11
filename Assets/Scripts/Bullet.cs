using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shellSpeed = 10f;
    public int shellDamage = 1;
    public float shellRange = 10f;

    private Vector2 startPosition;
    private float passedDistance = 0f;
    private Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        passedDistance = Vector2.Distance(transform.position, startPosition);
        if (passedDistance >= shellRange)
        {
            // DisableObject();
            Destroy(gameObject);
        }
    }

    void OnEnable() {
        GameObject[] waterTiles = GameObject.FindGameObjectsWithTag("Water");
        foreach (GameObject water in waterTiles) {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), water.gameObject.GetComponent<Collider2D>(), true);
        }
    }

    private void DisableObject()
    {
        rigid2D.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    public void Initialize()
    {
        startPosition = transform.position;
        Debug.Log(rigid2D.velocity);
        rigid2D.velocity = transform.up * shellSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Water") {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>(), true);
        }
        else {
            Destroy(gameObject);
        }
    }


}
