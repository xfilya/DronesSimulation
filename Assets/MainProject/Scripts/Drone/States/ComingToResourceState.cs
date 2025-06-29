
using UnityEngine;

public class ComingToResourceState : IState
{
    private Resource _selectedResource;
    private Drone _drone;
    private StateMachine _stateMachine;

    private float _stoppingDistance = 2.35f;

    public ComingToResourceState(Drone drone, Resource selectedResource, StateMachine stateMachine)
    {
        _selectedResource = selectedResource;
        _drone = drone;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Debug.Log("[ComingToResourceState] Started");

        _drone.NavMeshAgent.isStopped = false;
        _drone.NavMeshAgent.SetDestination(_selectedResource.transform.position);
    }

    public void Exit()
    {
        Debug.Log("[ComingToResourceState] Exited");
    }

    public void Update()
    {
        Debug.Log("[ComingToResourceState] Update");

        if (Vector3.Distance(_drone.transform.position, _selectedResource.transform.position) <= _stoppingDistance)
        {
            _drone.NavMeshAgent.isStopped = true;
            _stateMachine.SetState(new HarvestResourceState(_drone, _stateMachine, _selectedResource));
            Debug.Log("Got to resource!");
        }
    }
}