using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicRig : MonoBehaviour
{
    public Transform playerHead;
    public CapsuleCollider bodyCollider;

    public float bodyHeigthMin = 2f;
    public float bodyHeigthMax = 5;

    // Update is called once per frame
    void Start()
    {
        bodyCollider.height = Mathf.Clamp(playerHead.localPosition.y, bodyHeigthMin, bodyHeigthMax);
        print(bodyCollider.height);
        bodyCollider.center = new Vector3(playerHead.localPosition.x, bodyCollider.height / 2, playerHead.localPosition.z);
        print(bodyCollider.center);
    }
}
