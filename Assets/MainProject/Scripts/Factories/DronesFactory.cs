

using System;
using UnityEngine;

public class DronesFactory
{
    private Drone _dronePrefab;

    public DronesFactory(Drone resourcePrefab)
    {
        _dronePrefab = resourcePrefab;
    }

    public event Action<Drone> OnResourceSpawned;

    public Drone Spawn(Vector3 position, Quaternion rotation, Transform content)
    {
        var drone = GameObject.Instantiate(_dronePrefab, position, rotation, content);
        drone.Initialize();

        OnResourceSpawned?.Invoke(drone);

        return drone;
    }
}