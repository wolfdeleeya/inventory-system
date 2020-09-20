using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    
    [SerializeField] private float _pickupProximity;
    private Camera _camera;
    private Rigidbody2D _body;
    private PlayerControls _controls = null;
    private Vector2 _movement = Vector2.zero;
    delegate void DetectionMethod();
    private DetectionMethod _detectionMethod;

    private void Awake()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _controls = new PlayerControls();
        _controls.Gameplay.Click.performed += ctx => Click();
    }

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        _detectionMethod?.Invoke();
        _body.velocity = _movement * MovementSpeed;
    }

    private void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>().normalized;
    }

    private void Click()
    {
        Vector2 clickPos = _camera.ScreenToWorldPoint((Vector3)Mouse.current.position.ReadValue());
        Collider2D col = Physics2D.OverlapPoint(clickPos);
        if (col == null)
            return;

        GameObject obj = col.gameObject;
        if (obj.tag == "Item" && Vector2.Distance(obj.transform.position,transform.position)<_pickupProximity)
        {
            PickUpItem(obj);
        }

    }

    private void PickUpItem(GameObject obj)
    {
        //TODO: NAPRAVI PICKUP LOGIKU
        Destroy(obj);
    }

    private void OverlapCircle()
    {
        Debug.Log(LayerMask.GetMask("Pickups"));
        Collider2D col = Physics2D.OverlapCircle(transform.position,_pickupProximity,LayerMask.GetMask("Pickups"));
        if (col == null)
            return;
        Debug.Log(col.gameObject.name);

        GameObject obj = col.gameObject;
        if (obj.tag == "Item" && Vector2.Distance(obj.transform.position, transform.position) < _pickupProximity)
        {
            PickUpItem(obj);
        }
    }

    public void Style1()
    {
        _detectionMethod = null;
        _controls.Gameplay.Click.Enable();
    }

    public void Style2()
    {
        _detectionMethod = OverlapCircle;
        _controls.Gameplay.Click.Disable();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, _pickupProximity);
    }

    private void OnEnable() => _controls.Enable();

    private void OnDisable() => _controls.Disable();

}
