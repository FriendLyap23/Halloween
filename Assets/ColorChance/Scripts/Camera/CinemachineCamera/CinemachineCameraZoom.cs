using UnityEngine;
using Cinemachine;
public class CinemachineCameraZoom : MonoBehaviour
{
    private CinemachineComponentBase _componentBase;
    private float _cameraDistance;

    [SerializeField] private CinemachineVirtualCamera _cinemachineVertualCamera;
    [SerializeField] private float _sensitivity;

    private void Awake()
    {
        if (_componentBase == null)
            _componentBase = _cinemachineVertualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            _cameraDistance = Input.GetAxis("Mouse ScrollWheel") * _sensitivity;

            if (_componentBase is CinemachineFramingTransposer)
                (_componentBase as CinemachineFramingTransposer).m_CameraDistance -= _cameraDistance;
        }
    }



}
