using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayers;
    private bool isGrounded;
    private Vector3 _moveDirection;

    private Rigidbody rb;
    private float depth;
    
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);
        InputManager.SetGameControls();

        rb = GetComponent<Rigidbody>();
        depth = GetComponent<Collider>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (speed * Time.deltaTime * _moveDirection);
        CheckGround();
    }

    public void SetMovementDirection(Vector3 currentDirection)
    {
        _moveDirection = currentDirection;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, depth,groundLayers);
        Debug.DrawRay(transform.position, Vector3.down * depth, 
            Color.green, 0 , false);
    }

}