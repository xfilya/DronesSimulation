

using System.Linq;
using UnityEngine;

public class FindingResourceState : IState
{
    private bool _isActive;

    private bool _isResourceFound;

    private Drone _drone;
    private StateMachine _stateMachine;
    private Vector3 _centerPosition;

    public FindingResourceState(Drone drone, StateMachine stateMachine)
    {
        _drone = drone;
        _centerPosition = drone.transform.position;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Debug.Log("[FindingResourceState] Started");

        _isActive = true;
    }

    public void Exit()
    {
        Debug.Log("[FindingResourceState] Exited");

        _isActive = false;
    }

    public void Update()
    {
        Debug.Log("[FindingResourceState] Update");

        if (_isActive)
        {
            if (_isResourceFound)
                return;

            FindResource();
        }
    }

    private void FindResource()
    {
        if (GameData.Instance.SpawnedResources.Count > 0)
        {
            var orderedResources = GameData.Instance.SpawnedResources.OrderBy(
            (res) => Vector3.Distance(_centerPosition, res.transform.position)).ToList();

            for (int i = 0; i < orderedResources.Count; i++)
            {
                if (orderedResources[i].IsFree)
                {
                    var selectedResource = orderedResources[i];
                    selectedResource.IsFree = false;
                    _isResourceFound = true;

                    _stateMachine.SetState(new ComingToResourceState(_drone, selectedResource, _stateMachine));

                    Debug.Log($"{_drone.name} found a resource: {selectedResource}!");
                    return;
                }

                Debug.Log("Resource is already taken, finding next!");
            }
        }
    }
}