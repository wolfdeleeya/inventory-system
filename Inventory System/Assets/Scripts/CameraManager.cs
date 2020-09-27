using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private Transform _playerTransform;

    private PlayerController _playerController;
    private Camera _camera;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _playerController = _playerTransform.gameObject.GetComponent<PlayerController>();
        _camera = GetComponent<Camera>();
    }

    public Vector3 ScreenToWorldPoint(Vector3 vec)
    {
        return _camera.ScreenToWorldPoint(vec);
    }

    public IEnumerator SwitchFocus(Transform newTarget, float duration)
    {
        _playerController.BlockInput();
        _virtualCamera.Follow = newTarget;

        yield return new WaitForSeconds(duration);
        _playerController.AllowInput();
        _virtualCamera.Follow = _playerTransform;
    }
}
