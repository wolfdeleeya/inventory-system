using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;

    private Rigidbody2D _body;
    private PlayerControls _controls = null;
    private Vector2 _movement = Vector2.zero;

    private void Awake()
    {
        _controls = new PlayerControls();
    }

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        _body.velocity = _movement * MovementSpeed;
    }

    private void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>().normalized;
    }

    private void OnEnable() => _controls.Enable();

    private void OnDisable() => _controls.Disable();
    
}
