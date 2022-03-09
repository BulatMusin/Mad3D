using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentalBillboard : MonoBehaviour
{
    public Transform toFace;
   

    private float theta;
    private Vector3 a;
    Animator anim;
    bool toRotate;
   
    public GameObject otherObject;
 Animator otherAnimator;
 void Awake () {
     otherAnimator = otherObject.GetComponent<Animator> ();
 }

    void Update()
    {
      GetAngleIndex();
    }
    void GetAngleIndex()
    {  
        a = toFace.position - transform.position;

        a.Normalize();
        var b = transform.forward;
        

        theta = Mathf.Acos(Vector3.Dot(a, b)) * Mathf.Rad2Deg;
        if(toRotate)
        {
        if (a.x * a.z < 0)
            theta = 360.0f - theta;

        if (theta >= 292.5f && theta < 337.5f)
            anim.Play("Backward");
        else if (theta >= 22.5f && theta < 67.5f)
           anim.Play("RForward");
        else if (theta >= 67.5f && theta < 112.5f)
           anim.Play("Left");
        else if (theta >= 112.5f && theta < 157.5f)
            anim.Play("LForward");
        else if (theta >= 157.5f && theta < 202.5f)
            anim.Play("Forward");
        else if (theta >= 202.5f && theta < 247.5f)
             anim.Play("RForward");
        else if (theta >= 247.5f && theta < 292.5f)
             anim.Play("Left");
        else if (theta >= 337.5f || theta < 22.5f)
             anim.Play("LForward");
        }
    }

    private Rect guiPos = new Rect(0, 0, 720, 30);
    void OnGUI()
    {
        GUI.Label(guiPos, "Angle from the Player is: " + theta + " and forward=" + transform.forward + " and vectorToTarget=" + a);
    }
}
