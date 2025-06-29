using System.Collections;
using UnityEngine;

public class ResourceSpawnBehaviour : MonoBehaviour
{
    public float SpawnIntervalSec { get; set; } = 1f;

    [SerializeField] private Resource _resourcePrefab;
    [SerializeField] private Transform _content;

    [SerializeField] private BoxCollider _spawnCollider;

    private ResourceFactory _resourceFactory;

    public void Initialize()
    {
        _resourceFactory = new(_resourcePrefab);

        StartCoroutine(ResourceSpawnCoroutine());
    }

    private Vector3 GetRandomPositionInBounds()
    {
        Bounds bounds = _spawnCollider.bounds;

        Vector3 min = bounds.min;
        Vector3 max = bounds.max;

        float x = UnityEngine.Random.Range(min.x, max.x);
        float y = _spawnCollider.transform.position.y;
        float z = UnityEngine.Random.Range(min.z, max.z);

        return new Vector3(x, y, z);
    }

    private IEnumerator ResourceSpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnIntervalSec);

            Vector3 position = GetRandomPositionInBounds();
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 180), 0);

            var resource = _resourceFactory.Spawn(position, rotation, _content);

            GameData.Instance.SpawnedResources.Add(resource);

            Debug.Log("[ResourceSpawnBehaviour] RESOURCE SPAWNED");
        }
    }

    public Resource SpawnResourceWithParameters()
    {
        Vector3 position = GetRandomPositionInBounds();
        Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
        var resource = _resourceFactory.Spawn(position, rotation, _content);
        GameData.Instance.SpawnedResources.Add(resource);
        return resource;
    }
}