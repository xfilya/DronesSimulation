

using UnityEngine;

public class ComingToBaseState : IState
{
    private Drone _drone;
    private StateMachine _stateMachine;
    private Resource _selectedResource;

    private float _stoppingDistance = 5f;

    public ComingToBaseState(Drone drone, StateMachine stateMachine, Resource selectedResource)
    {
        _drone = drone;
        _stateMachine = stateMachine;
        _selectedResource = selectedResource;
    }

    public void Enter()
    {
        Debug.Log("[ComingToBaseState] Started");

        _drone.NavMeshAgent.isStopped = false;
        _drone.NavMeshAgent.SetDestination(_drone.DroneBase.transform.position);
    }

    public void Exit()
    {
        Debug.Log("[ComingToBaseState] Exited");
    }

    public void Update()
    {
        Debug.Log("[ComingToBaseState] Update");

        if (Vector3.Distance(_drone.transform.position, _drone.DroneBase.transform.position) <= _stoppingDistance)
        {
            PutResourceToBase();
        }
    }

    private void PutResourceToBase()
    {
        _drone.NavMeshAgent.isStopped = true;
        GameData.Instance.SpawnedResources.Remove(_selectedResource);
        GameObject.Destroy(_selectedResource.gameObject);

        _drone.PutResourceToBase(_selectedResource);
        _stateMachine.SetState(new FindingResourceState(_drone, _stateMachine));
        Debug.Log("Got to base!");
    }
}
