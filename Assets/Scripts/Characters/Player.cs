using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float height;
    private Vector3 _moveDir;
    private Vector2 _jumpDir;
    private Rigidbody rb;
    
    void Start()
    {
        InputManager.Init(myPlayer: this);
        InputManager.Gamemode();
        
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        Vector3 movement = new Vector3(_moveDir.x * speed, _jumpDir.y * height, _moveDir.z * speed);
        
        rb.velocity = movement;
    }

    public void SetMovementDirection(Vector3 newDirection)
    {
        _moveDir = newDirection;
    }

    public void SetJumpDirection(Vector2 newYDir)
    {
        _jumpDir = newYDir;
    }
}