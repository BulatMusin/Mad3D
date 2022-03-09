using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingVector : MonoBehaviour
{

    Vector3 cameraDirection, direction;

    public Transform player;
    public float angle;

    void Update()
    {Vector3 forward = transform.TransformDirection(Vector3.forward);
direction = player.transform.position -transform.position;
angle = Vector3.SignedAngle(forward , direction , Vector3.up);
StartCoroutine(LookAtPlayer());
    }

    IEnumerator LookAtPlayer()
    {
        yield return new WaitForSeconds(0.6f);
        cameraDirection = Camera.main.transform.forward;
        cameraDirection.y = 0;
        transform.rotation= Quaternion.LookRotation(cameraDirection);
    }
}
