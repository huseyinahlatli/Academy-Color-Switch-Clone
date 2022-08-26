using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 100f;
    private float _passedTime = 30f;
    private float _currentTime;

    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }

    private void ChangeDirectionOfRotation() // not used
    {
        _currentTime = Time.time;
        if (_currentTime >= _passedTime)
        {
            rotateSpeed *= -1f;
            _passedTime += 30f;
        }
    }
}


