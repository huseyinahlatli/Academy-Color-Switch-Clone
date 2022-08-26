using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10f);
    [SerializeField] private float lerpValue = 2f;
    private void LateUpdate()
    {
        if(target.position.y >  transform.position.y)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue * Time.deltaTime);
        }
    }
}
