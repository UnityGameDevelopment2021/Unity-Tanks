using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWall : Wall
{

    // Start is called before the first frame update
    void Start()
    {
        wallHP = 2;
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[wallHP];
    }

    /* TODO change collison object name
     */ 
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "TestPlayer") {
            PlayerTank playerTank = collision.gameObject.GetComponent<PlayerTank>();
            if (wallHP <= 0) {
                Destroy(gameObject);
            }
            else {
                wallHP -= playerTank.getPower();
                sprite = sprites[wallHP];
                spriteRenderer.sprite = sprite;
            }
        }
    }

}