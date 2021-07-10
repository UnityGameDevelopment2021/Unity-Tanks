using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public  Sprite[] sprites;
    protected Sprite sprite;
    protected BoxCollider2D boxCollider;
    protected SpriteRenderer spriteRenderer;

    [SerializeField] protected int wallHP;

}
