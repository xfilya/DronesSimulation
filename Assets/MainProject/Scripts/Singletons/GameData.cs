

using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [field: SerializeField] public DroneBase BlueBase {  get; private set; }
    [field: SerializeField] public DroneBase RedBase { get; private set; }

    public List<Drone> SpawnedDrones = new();
    public List<Resource> SpawnedResources = new();

    public static GameData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}