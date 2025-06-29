using System;
using UnityEngine;

public class ResourceFactory
{
    private Resource _resourcePrefab;

    public ResourceFactory(Resource resourcePrefab)
    {
        _resourcePrefab = resourcePrefab;
    }

    public event Action<Resource> OnResourceSpawned;

    public Resource Spawn(Vector3 position, Quaternion rotation, Transform content)
    {
        var resource = GameObject.Instantiate(_resourcePrefab, position, rotation, content);
        resource.Initialize();

        OnResourceSpawned?.Invoke(resource);

        return resource;
    }    
}
