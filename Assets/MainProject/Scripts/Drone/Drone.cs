

using System;
using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour
{
    [field: SerializeField] public Fraction Fraction {  get; private set; }

    [SerializeField] private ParticleSystem _putResourceParticles;

    public event Action<Resource> OnPutResourceToBase;
    public DroneBase DroneBase { get; private set; }
    public NavMeshAgent NavMeshAgent {  get; private set; }

    public Resource SelectedResource { get; set; }

    private StateMachine _stateMachine;


    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        DroneBase = SetDroneBaseTransform(Fraction);

        _stateMachine = new();
        _stateMachine.SetState(new FindingResourceState(this, _stateMachine));        
    }

    public void PutResourceToBase(Resource resource)
    {
        _putResourceParticles.Play();
        OnPutResourceToBase?.Invoke(resource);
    }

    private DroneBase SetDroneBaseTransform(Fraction fraction) => fraction switch
    {
        Fraction.Blue => GameData.Instance.BlueBase,
        Fraction.Red => GameData.Instance.RedBase,
        _ => throw new System.Exception("Not existing fraction(?)"),
    };

    private void Update()
    {
        _stateMachine.Update();
    }
}