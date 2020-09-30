using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;

public class PlayerControllerAndroid : MonoBehaviour, UIListener
{
    public float MovementSpeed;

    [SerializeField] private float _pickupProximity;
    [SerializeField] private LayerMask _overlapLayer;

    [SerializeField] private GraphicRaycaster _graphicRaycaster;
    private PointerEventData _pointerEventData;
    private List<RaycastResult> _results;

    private Transform _transform;
    private Rigidbody2D _body;
    private PlayerControls _controls = null;
    private Vector2 _movement = Vector2.zero;
    private Animator _animator;
    private Pickuper _pickuper;
    private PlayerInput _input;
    private List<PlayerMovementListener> _listeners;

    private int _xAxisHash = Animator.StringToHash("Xaxis");
    private int _yAxisHash = Animator.StringToHash("Yaxis");

    private Vector2[] _prevTouchPos;

    private Vector3 RandomVec
    {
        get
        {
            Vector3 ranVec = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
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
        _prevTouchPos = new Vector2[2];
        _pointerEventData = new PointerEventData(null);
        _results = new List<RaycastResult>();
        EnhancedTouchSupport.Enable();
    }

    private void Start()
    {
        UIManager.Instance.AddListener(this);
        AddListener(Equipment.Instance);
    }

    private void Update()
    {
        UnityEngine.InputSystem.Utilities.ReadOnlyArray<UnityEngine.InputSystem.EnhancedTouch.Touch> touches = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches;
        switch (touches.Count)
        {
            case 1:
                _prevTouchPos[0] = touches[0].screenPosition;
                if (touches[0].phase == UnityEngine.InputSystem.TouchPhase.Began)
                    break;
                _pointerEventData.position = touches[0].screenPosition;
                _graphicRaycaster.Raycast(_pointerEventData, _results);
                if (_results.Count >= 1)
                {
                    GameObject obj = _results[0].gameObject;

                    if (!obj.CompareTag("Cell"))
                        ItemHolder.Instance.HideDescription();
                    _results.Clear();
                }
                else
                {
                    ItemHolder.Instance.HideDescription();
                }
                break;
            case 2:
                if (UIManager.Instance.IsMenuOpened)
                    break;
                if (touches[1].phase != UnityEngine.InputSystem.TouchPhase.Began)
                {
                    float currDist = Vector2.Distance(touches[0].screenPosition, touches[1].screenPosition);
                    float prevDist = Vector2.Distance(_prevTouchPos[0], _prevTouchPos[1]);

                    float delta = prevDist - currDist;
                    CameraManager.Instance.CurrentZoom += delta * Time.deltaTime;
                }
                _prevTouchPos[0] = touches[0].screenPosition;
                _prevTouchPos[1] = touches[1].screenPosition;
                break;
        }

        InformListeners(_body.velocity.magnitude * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        OverlapCircle();
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
        Collider2D col = Physics2D.OverlapCircle(_transform.position, _pickupProximity, _overlapLayer);
        if (col == null)
            return;

        GameObject obj = col.gameObject;
        if (obj.CompareTag("Item") && Vector2.Distance(obj.transform.position, _transform.position) < _pickupProximity)
        {
            PickUpItem(obj);
        }
    }

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
            BlockMovement();
        }
        else
        {
            AllowMovement();
        }
    }
}