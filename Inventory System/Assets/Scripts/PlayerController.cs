using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour, UIListener
{
    public float MovementSpeed;
    
    [SerializeField] private float _pickupProximity;
    [SerializeField] private float _switchFocusDuration;
    [SerializeField] private LayerMask _overlapLayer;


    private Transform _transform;
    private Rigidbody2D _body;
    private PlayerControls _controls = null;
    private Vector2 _movement = Vector2.zero;
    private Action _detectionMethod;
    private Action _pickupMethod;
    private System.Action _clickMethod;
    private Animator _animator;
    private Pickuper _pickuper;
    private PlayerInput _input;
    private List<PlayerMovementListener> _listeners;

    private int _xAxisHash = Animator.StringToHash("Xaxis");
    private int _yAxisHash = Animator.StringToHash("Yaxis");

    private Vector3 RandomVec
    {
        get {
            Vector3 ranVec = new Vector3(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(-1f, 1f));
            return ranVec.normalized;
        }
    }

    private void Awake()
    {
        _transform = transform;
        _controls = new PlayerControls();
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _pickuper = GetComponent<Pickuper>();
        _input = GetComponent<PlayerInput>();
        _listeners = new List<PlayerMovementListener>();
        _clickMethod = Click;
        _pickupMethod = OverlapCircle;
    }

    private void Start()
    {
        UIManager.Instance.AddListener(this);
        AddListener(Equipment.Instance);
    }

    private void Update()
    {
        InformListeners(_body.velocity.magnitude * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _detectionMethod?.Invoke();
        _body.velocity = _movement * MovementSpeed;
    }

    private void InformListeners(float distance)
    {
        foreach (PlayerMovementListener listener in _listeners)
            listener.PlayerMoved(distance);
    }

    private void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>().normalized;
        _animator.SetFloat(_xAxisHash, _movement.x);
        _animator.SetFloat(_yAxisHash, _movement.y);
    }

    private void Click()
    {
        Vector2 clickPos = CameraManager.Instance.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Collider2D col = Physics2D.OverlapPoint(clickPos);
        if (col == null)
            return;

        GameObject obj = col.gameObject;
        if (obj.CompareTag("Item") && Vector2.Distance(obj.transform.position,_transform.position)<_pickupProximity)
        {
            PickUpItem(obj);
        }
    }

    private void UIClick()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && !ItemHolder.Instance.IsEmpty)
            DropItemOut();
    }

    private void OnInventory()
    {
        UIManager.Instance.ChangeInventoryState();
    }

    public void OnClick()
    {
        _clickMethod?.Invoke();
    }

    void Print(string pr) => Debug.Log(pr);

    private void OnEquip()
    {
        UIManager.Instance.ChangeEquipState();
    }

    private void OnAttributes()
    {
        UIManager.Instance.ChangeAttributesState();
    }

    public void OnDrop()
    {
        if (!ItemHolder.Instance.IsEmpty)
            DropItemOut();
    }

    public void OnSpawn()
    {
        Vector2 pos = CameraManager.Instance.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        ItemSpawner.Instance.SpawnRandomItem(new Vector3(pos.x,pos.y,-1));
    }

    public void OnView()
    {
        Vector3 position = CameraManager.Instance.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Collider2D collider = Physics2D.OverlapPoint(position);
        Debug.Log(collider);
        if (collider != null)
            StartCoroutine(CameraManager.Instance.SwitchFocus(collider.transform, _switchFocusDuration));
    }

    public void OnPickup() => _pickupMethod?.Invoke();

    public void DropItemOut()
    {
        ItemInfo item = ItemHolder.Instance.InAirItem;
        item.SpawnWorldItem(_transform.position + RandomVec * _pickupProximity * 1.5f);
        ItemHolder.Instance.DropItem();
        Destroy(item.gameObject);
    }

    private void PickUpItem(GameObject obj)
    {
        _pickuper.Pickup(obj.GetComponent<Item>());
        Destroy(obj);
    }

    private void OverlapCircle()
    {
        Collider2D col = Physics2D.OverlapCircle(_transform.position,_pickupProximity,_overlapLayer);
        if (col == null)
            return;

        GameObject obj = col.gameObject;
        if (obj.CompareTag("Item") && Vector2.Distance(obj.transform.position, _transform.position) < _pickupProximity)
        {
            PickUpItem(obj);
        }
    }

    private void CircleCast()
    {
        RaycastHit2D hit;
        if(hit = Physics2D.CircleCast(_transform.position, _pickupProximity / 4, _movement, _pickupProximity / 2, _overlapLayer)){
            PickUpItem(hit.transform.gameObject);
        }
        
    }

    public void SwitchContinuousPickupStyle()
    {
        if (_detectionMethod == null)
        {
            _detectionMethod = OverlapCircle;
            _clickMethod = null;
        }
        else
        {
            _detectionMethod = null;
            _clickMethod = Click;
        }
    }

    public void SwitchInputPickupStyle()
    {
        if (_pickupMethod == OverlapCircle)
            _pickupMethod = CircleCast;
        else
            _pickupMethod = OverlapCircle;
    }

    public void BlockInput() => _input.enabled = false;

    public void AllowInput() => _input.enabled = true;

    public void BlockMovement() => _controls.Gameplay.Move.Disable();

    public void AllowMovement() => _controls.Gameplay.Move.Enable();

    private void OnEnable() => _controls.Enable();

    private void OnDisable() => _controls.Disable();

    public void AddListener(PlayerMovementListener listener) => _listeners.Add(listener);

    public void RemoveListener(PlayerMovementListener listener) => _listeners.Remove(listener);

    public void UIStateChanged()
    {
        if (UIManager.Instance.IsMenuOpened)
        {
            _clickMethod = UIClick;
            BlockMovement();
        }
        else
        {
            if (_detectionMethod == null)
                _clickMethod = Click;
            else
                _clickMethod = null;
            AllowMovement();
        }
    }
}
