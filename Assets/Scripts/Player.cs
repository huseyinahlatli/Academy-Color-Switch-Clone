using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = Vector2.up * jumpForce;
        }
    }
}
