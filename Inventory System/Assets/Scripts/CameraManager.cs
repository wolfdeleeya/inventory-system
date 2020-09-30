using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private float _minZoom;
    [SerializeField] private float _maxZoom;
    [SerializeField] private float _currentZoom;

    private PlayerController _playerController;
    private Camera _camera;

    public float CurrentZoom
    {
        get { return _currentZoom; }
        set
        {
            _currentZoom = Mathf.Clamp(value, _minZoom, _maxZoom);
            _virtualCamera.m_Lens.OrthographicSize = _currentZoom;
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        if(_playerTransform != null)
            _playerController = _playerTransform.gameObject.GetComponent<PlayerController>();
        _camera = GetComponent<Camera>();
        CurrentZoom = CurrentZoom;
    }

    public Vector3 ScreenToWorldPoint(Vector3 vec)
    {
        return _camera.ScreenToWorldPoint(vec);
    }

    public IEnumerator SwitchFocus(Transform newTarget, float duration)
    {
        if (_playerTransform == null)
            yield return null;
        _playerController.BlockInput();
        _virtualCamera.Follow = newTarget;

        yield return new WaitForSeconds(duration);
        _playerController.AllowInput();
        _virtualCamera.Follow = _playerTransform;
    }
}
