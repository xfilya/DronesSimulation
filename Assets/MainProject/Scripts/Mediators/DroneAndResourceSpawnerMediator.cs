

using UnityEngine;

public class DroneAndResourceSpawnerMediator : MonoBehaviour
{
    [SerializeField] private ResourceSpawnBehaviour _resourceSpawnBehaviour;

    public void Initialize()
    {
        foreach (var drone in GameData.Instance.SpawnedDrones)
        {
            drone.OnPutResourceToBase += OnDronPutResourceToBase;
        }
    }

    private void OnDronPutResourceToBase(Resource resource)
    {
        //TODO: событие, когда дрон отнес ресурс на базу
        Debug.Log("Sent resource to base!");
    }
}