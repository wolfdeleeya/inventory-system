using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;

public class PlayerController : MonoBehaviour, UIListener
{
    public float MovementSpeed;
    
    [SerializeField] private float _pickupProximity;
    private Camera _camera;
    private Rigidbody2D _body;
    private PlayerControls _controls = null;
    private Vector2 _movement = Vector2.zero;
    private Action _detectionMethod;
    private System.Action _clickMethod;
    private Animator _animator;

    private Vector3 RandomVec
    {
        get {
            Vector3 ranVec = new Vector3(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(-1f, 1f));
            return ranVec.normalized;
        }
    }

    private void Awake()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _controls = new PlayerControls();
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _clickMethod = Click;
    }

    private void Start()
    {
        UIManager.Instance.AddListener(this);
    }

    private void FixedUpdate()
    {
        _detectionMethod?.Invoke();
        _body.velocity = _movement * MovementSpeed;
    }

    private void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>().normalized;
        _animator.SetFloat("Xaxis", _movement.x);
        _animator.SetFloat("Yaxis", _movement.y);
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
        Vector2 pos = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        ItemSpawner.Instance.SpawnRandomItem(new Vector3(pos.x,pos.y,-1));
    }

    public void DropItemOut()
    {
        ItemInfo item = ItemHolder.Instance.InAirItem;
        item.SpawnWorldItem(transform.position + RandomVec * _pickupProximity * 1.5f);
        ItemHolder.Instance.DropItem();
        Destroy(item.gameObject);
    }

    private void PickUpItem(GameObject obj)
    {
        obj.GetComponent<Item>().Pickup();
        Destroy(obj);
    }

    private void OverlapCircle()
    {
        Debug.Log(LayerMask.GetMask("Pickups"));
        Collider2D col = Physics2D.OverlapCircle(transform.position,_pickupProximity,LayerMask.GetMask("Pickups"));
        if (col == null)
            return;

        GameObject obj = col.gameObject;
        if (obj.tag == "Item" && Vector2.Distance(obj.transform.position, transform.position) < _pickupProximity)
        {
            PickUpItem(obj);
        }
    }

    public void Style1()
    {
        _detectionMethod = null;
        _clickMethod = Click;
    }

    public void Style2()
    {
        _detectionMethod = OverlapCircle;
        _clickMethod = null;
    }

    private void OnEnable() => _controls.Enable();

    private void OnDisable() => _controls.Disable();

    public void UIStateChanged()
    {
        if (UIManager.Instance.IsMenuOpened)
            _clickMethod = UIClick;
        else
        {
            if (_detectionMethod == null)
                _clickMethod = Click;
            else
                _clickMethod = null;
        }
    }
}
