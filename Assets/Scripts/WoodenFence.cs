using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenFence : Wall
{
    // Start is called before the first frame update
    void Start()
    {
        wallHP = 1;
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Bullet(Clone)") {
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

        if(collision.gameObject.name == "Tank") {
            Destroy(gameObject);
        }
    }
}
