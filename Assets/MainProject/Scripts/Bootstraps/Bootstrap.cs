

using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private ResourceSpawnBehaviour _resourceSpawnBehaviour;
    [SerializeField] private DroneAndResourceSpawnerMediator _droneAndResourceSpawnerMediator;
    
    private void Awake()
    {
        _resourceSpawnBehaviour.Initialize();
        _droneAndResourceSpawnerMediator.Initialize();
    }
}