using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public int _remainingCandies { get; set; } = 300;

    public delegate void InstantiateCandyDelegate();
    public InstantiateCandyDelegate _instantiateCandyDelegate;

    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] public int _numberOfSpawnObject;

    [SerializeField] private float _spawnHeight;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private LayerMask _obstacleLayer;

    private void Awake() 
    {
        _instantiateCandyDelegate += InstantiateCandy;
    }

    private void Start()
    {
        InstantiateCandy();
    }

    private void InstantiateCandy() 
    {
        for (int i = 0; i < _remainingCandies; i++)
        {
            Vector3 randomSpawnPoint = GetRandomSpawnPoint();
            Instantiate(_objectToSpawn, randomSpawnPoint, Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPoint() 
    {
        Vector3 randomPoint = Vector3.zero;
        bool validSpawnPointFound = false;

        while (!validSpawnPointFound)
        {
            randomPoint = transform.position + Random.insideUnitSphere * _spawnRadius;
            randomPoint.y = _spawnHeight;

            if (!Physics.CheckSphere(randomPoint,  
                _objectToSpawn.GetComponent<Collider>().bounds.extents.x, _obstacleLayer))
                validSpawnPointFound = true;
        }
        return randomPoint;
    }

}
