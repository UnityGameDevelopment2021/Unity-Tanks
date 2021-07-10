using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWallDestruction : MonoBehaviour
{

    BoxCollider2D collider;
    float newColliderY = 0;
    float newColliderX = 0;
    public Sprite[] sprites;
    Sprite sprite;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(collider.bounds.extents.x == 0 || collider.bounds.extents.y == 0) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 centerOfBox = collider.bounds.center;
        float boxMinX = 0;
        float boxMaxX = 0;
        float boxMinY = 0;
        float boxMaxY = 0;
        if (centerOfBox.x < 0) {
            boxMinX = centerOfBox.x - (collider.bounds.size.x / 2);
        } else {
            boxMinX = Mathf.Abs((collider.bounds.size.x / 2) - centerOfBox.x);
        }

        if (centerOfBox.y < 0) {
            boxMinY = centerOfBox.y - (collider.bounds.size.y / 2);
        }
        else {
            boxMinY = Mathf.Abs((collider.bounds.size.y / 2) - centerOfBox.y);
        }

        boxMaxX = (boxMinX + collider.bounds.size.x);
        boxMaxY = (boxMinY + collider.bounds.size.y);

        if (collision.gameObject.name == "TestPlayer") {
            Vector2 contactPoint = collision.contacts[0].point;
            string sideOfCollision = checkSideOfCollision(boxMinX, boxMaxX, boxMinY, boxMaxY, contactPoint, centerOfBox);
            float posx = 0;
            float posy = 0;
            switch (sideOfCollision) {

                case "bottom":
                    posx = collider.bounds.center.x;
                    posy = (collider.bounds.center.y - collider.bounds.extents.y) + 0.04f;
                    newColliderY = collider.size.y - 0.08f;
                    collider.size = new Vector2(collider.size.x, newColliderY);
                    collider.offset = new Vector2(collider.offset.x, collider.offset.y + 0.04f);
                    createMask(posx, posy, 0);
                    break;
                case "top":
                    posx = collider.bounds.center.x;
                    posy = (collider.bounds.center.y + collider.bounds.extents.y) - 0.04f;
                    newColliderY = collider.size.y - 0.08f;
                    collider.size = new Vector2(collider.size.x, newColliderY);
                    collider.offset = new Vector2(collider.offset.x, collider.offset.y - 0.04f);
                    createMask(posx, posy, 0);
                    break;

                case "left":
                    posx = (collider.bounds.center.x - collider.bounds.extents.x) + 0.04f;
                    posy = collider.bounds.center.y;
                    newColliderX = collider.size.x - 0.08f;
                    collider.size = new Vector2(newColliderX, collider.size.y);
                    collider.offset = new Vector2(collider.offset.x + 0.04f, collider.offset.y);
                    createMask(posx, posy, 90);
                    break;
                case "right":
                    posx = (collider.bounds.center.x + collider.bounds.extents.x) - 0.04f;
                    posy = collider.bounds.center.y;
                    newColliderX = collider.size.x - 0.08f;
                    collider.size = new Vector2(newColliderX, collider.size.y);
                    collider.offset = new Vector2(collider.offset.x - 0.04f, collider.offset.y);
                    createMask(posx, posy, 90);
                    break;
            }
        }
    }

    private string checkSideOfCollision(float boxMinX, float boxMaxX, float boxMinY, float boxMaxY, Vector2 contactPoint, Vector2 centerOfBox) {
        if ((contactPoint.x >= boxMinX || Mathf.Approximately(contactPoint.x, boxMinX)) &&
            (contactPoint.x <= boxMaxX || Mathf.Approximately(contactPoint.x, boxMaxX)) &&
            contactPoint.y < centerOfBox.y) {
            return "bottom";
        }
        else if ((contactPoint.x >= boxMinX || Mathf.Approximately(contactPoint.x, boxMinX)) &&
                 (contactPoint.x <= boxMaxX || Mathf.Approximately(contactPoint.x, boxMaxX)) && 
                 contactPoint.y > centerOfBox.y) {
            return "top";
        }
        else if ((contactPoint.y >= boxMinY || Mathf.Approximately(contactPoint.y, boxMinY)) &&
                 (contactPoint.y <= boxMaxY || Mathf.Approximately(contactPoint.y, boxMaxY)) && 
                 contactPoint.x < centerOfBox.x) {
            return "left";
        }
        else return "right";

    }

    private void createMask(float posX, float posY, float rotation) {
        GameObject mask;
        mask = new GameObject("TestMask");
        mask.AddComponent<SpriteMask>();
        mask.transform.SetParent(gameObject.transform);
        mask.transform.position = new Vector2(posX, posY);
        var rotation2 = Quaternion.AngleAxis(rotation, Vector3.forward);
        mask.transform.rotation = rotation2;
        mask.GetComponent<SpriteMask>().sprite = Resources.Load<Sprite>("Environment/mask");
        Debug.Log(posX + ", " + posY);
    }
}
