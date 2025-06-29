

using DG.Tweening;
using UnityEngine;

public class HarvestResourceState : IState
{
    private StateMachine _stateMachine;
    private Drone _drone;
    private Resource _selectedResource;

    public HarvestResourceState(Drone drone, StateMachine stateMachine, Resource selectedResource)
    {
        _stateMachine = stateMachine;
        _drone = drone;
        _selectedResource = selectedResource;
    }

    public void Enter()
    {
        Debug.Log("[HarvestResourceState] Started");

        StartHarvestResourceSequence();
    }

    public void Exit()
    {
        Debug.Log("[HarvestResourceState] Exited");
    }

    public void Update()
    {
        Debug.Log("[HarvestResourceState] Update");
    }

    private void StartHarvestResourceSequence()
    {
        Debug.Log("Started harvesting resource!!!");

        var sequence = DOTween.Sequence();
        sequence.AppendInterval(2f);
        sequence.AppendCallback(() => _selectedResource.Harvest());
        sequence.AppendInterval(0.3f);
        sequence.AppendCallback(() => _stateMachine.SetState(new ComingToBaseState(_drone, _stateMachine, _selectedResource)));
    }
}