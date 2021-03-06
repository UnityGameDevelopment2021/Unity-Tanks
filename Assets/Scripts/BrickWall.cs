using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWall : Wall
{

    // Start is called before the first frame update
    void Start()
    {
        wallHP = 3;
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[wallHP];
    }

    /* TODO change collison object name
     */ 
    private void OnCollisionEnter2D(Collision2D collision) {

        if(collision.gameObject.name == "Bullet(Clone)") {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            wallHP -= bullet.shellDamage;
            if (wallHP <= 0) {
                Destroy(gameObject);
            }
            else {
                sprite = sprites[wallHP];
                spriteRenderer.sprite = sprite;
            }
        }
    }

}
