using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void GoToTarget(Vector3 target, float speed,bool changePos = false, float posOrNegative = 1)
    {
        Vector3 pos = rb.position;

        rb.MoveRotation(Quaternion.LookRotation(target));

        if (changePos)
        {
            pos +=   target * speed * Time.deltaTime;
            rb.MovePosition(pos);
        }

    }

}
