using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{
    public Animator anim;

    private Rigidbody [] rigidbodies;

    public float force;

    public bool enable;

    public bool dead;

     void Start()
    {
        rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
        SetEnabled(false);
    }

    public void SetEnabled(bool enabled){
        bool isKinematic = !enabled;

        foreach(Rigidbody rb in rigidbodies){
            rb.isKinematic = isKinematic;
            rb.detectCollisions = !isKinematic;
            rb.AddForce(Vector3.forward*force);
        }

        anim.enabled = !enabled;

    }

}
