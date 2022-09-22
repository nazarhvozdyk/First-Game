using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    // исходные значения камеры
    private Vector3 _startCameraPositionOffset;
    private Quaternion _startCameraRotationOffset;
    private float _startCameraFieldOfView;
    private Transform _startTarget;
    public CameraFollow cameraFollow;
    [Range(30, 150)]
    public float cameraFieldOfViewInUpgrateMode;
    private void Start()
    {
        _startCameraRotationOffset = _camera.transform.rotation;
        _startCameraFieldOfView = _camera.fieldOfView;
        _startTarget = cameraFollow.target;
    }

    // меняем объект за которым будет следить камера
    public void ChangeFollowingTarget(Transform newCameraFollowingTarget)
    {
        cameraFollow.target = newCameraFollowingTarget;
    }

    // сбрасываем настройки камеры к исходным
    public void ResetCamera()
    {
        _camera.transform.rotation = _startCameraRotationOffset;
        cameraFollow.target = _startTarget;
        StartCoroutine(ChangeCameraFieldOfView(_startCameraFieldOfView));
    }

    public void ChangeFieldOfView(float value)
    {
        // чтобы игра не выглядела безумно делаем ограничения
        float fieldOfView = Mathf.Clamp(value, 30f, 160f);
        // присваиваем значение не сразу а лерпом
        StartCoroutine(ChangeCameraFieldOfView(fieldOfView));
    }
    private IEnumerator ChangeCameraFieldOfView(float value)
    {
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, value, Time.deltaTime);
            yield return null;
        }
    }
}
