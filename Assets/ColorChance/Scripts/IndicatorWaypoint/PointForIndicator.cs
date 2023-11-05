using UnityEngine;

[ExecuteAlways]
public class PointForIndicator : MonoBehaviour
{
    [SerializeField] private Transform _pointerIconTransform;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Camera _camera;

    private void Update() 
    {
        Vector3 fromPlayerToObject = transform.position - _playerTransform.position;
        Ray ray = new Ray(_playerTransform.position, fromPlayerToObject);
        Debug.DrawRay(_playerTransform.position, fromPlayerToObject);

        Plane[] plane = GeometryUtility.CalculateFrustumPlanes(_camera);

        float minDistance = Mathf.Infinity;

        for (int i = 0; i < 4; i++)
        {
            if (plane[i].Raycast(ray, out float distance))
            {
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }
        }

        minDistance = Mathf.Clamp(minDistance, 0, fromPlayerToObject.magnitude);

        Vector3 worldPosition = ray.GetPoint(minDistance);

        _pointerIconTransform.position = _camera.WorldToScreenPoint(worldPosition);
    }
}
