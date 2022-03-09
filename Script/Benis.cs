using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Benis : MonoBehaviour
{
    public Camera dir;

    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    public void Update()
    {
        GetAngleIndex();
    }
    public void GetAngleIndex()
     {
         var dir = GetComponent<Camera>().transform.position - transform.parent.forward;
         var enemyAngle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
         if (enemyAngle < 0.0f)
             enemyAngle += 360;
         Debug.Log("Angle from the player is: " + enemyAngle);
         if (enemyAngle >= 292.5f && enemyAngle < 337.5f)
             spriteRenderer.sprite = sprites[0];
         else if (enemyAngle >= 22.5f && enemyAngle < 67.5f)
             spriteRenderer.sprite = sprites[1];
         else if (enemyAngle >= 67.5f && enemyAngle < 112.5f)
              spriteRenderer.sprite = sprites[2];
         else if (enemyAngle >= 112.5f && enemyAngle < 157.5f)
             spriteRenderer.sprite = sprites[3];
         else if (enemyAngle >= 157.5f && enemyAngle < 202.5f)
             spriteRenderer.sprite = sprites[4];
         else if (enemyAngle >= 202.5f && enemyAngle < 247.5f)
             spriteRenderer.sprite = sprites[5];
         else if (enemyAngle >= 247.5f && enemyAngle < 292.5f)
             spriteRenderer.sprite = sprites[6];
         else if (enemyAngle >= 337.5f || enemyAngle < 22.5f)
             spriteRenderer.sprite = sprites[7];
         //else return 0;
     }
}
