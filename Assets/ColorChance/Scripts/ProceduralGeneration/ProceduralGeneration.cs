using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    private int _randomPrefabCount;

    [SerializeField] private int _prefabCount;
    [SerializeField] private int _lengthArray;

    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private LayerMask _obstacleLayer;

    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _spawnHeight;

    private void Start()
    {
        _lengthArray = _prefabs.Length;

        Quaternion prefabRotation = _prefabs[_randomPrefabCount].transform.rotation;

        for (int i = 0; i < _prefabCount; i++)
        {
            Vector3 randomPoint = PrefabPosition();
            _randomPrefabCount = Random.Range(0, _lengthArray);
            Instantiate(_prefabs[_randomPrefabCount], randomPoint, prefabRotation);
        }
    }

    private Vector3 PrefabPosition()
    {
        Vector3 randomPoint = Vector3.zero;
        Vector3 halfExtents = new Vector3(10,10,10);

        bool validSpawnPointFound = false;


        while (!validSpawnPointFound)
        {
            randomPoint = transform.position + Random.insideUnitSphere * _spawnRadius;
            randomPoint.y = _spawnHeight;

            if (!Physics.CheckBox(randomPoint, halfExtents, Quaternion.identity, _obstacleLayer))
                validSpawnPointFound = true;
        }
        return randomPoint;
    }
}
