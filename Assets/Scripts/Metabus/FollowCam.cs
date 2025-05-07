using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform target; //Player

    void Start()
    {
        if (target == null)
            return;
    }
    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y;
        transform.position= pos;
    }
}
