using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantAttacks : MonoBehaviour
{

    private float stateTimer;
    
    public enum PeasantState
    {
        Idle,
        Shielding,
        ForwardSpikeAttack,
        SideSpikeAttack,
        Exhausted
    }
    
    private PeasantState currentState;
    
    // Start is called before the first frame update
    void Start()
    {
        
        SetState(PeasantState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetState(PeasantState newState)
    {
        
    }
    
    void EnterState(PeasantState state)
    {
        switch (state)
        {
            case PeasantState.Idle:
                stateTimer = 3f;
                break;
            
            case PeasantState.Shielding:
                stateTimer = 3f;
                break;
            
            case PeasantState.Exhausted:
                stateTimer = 3f;
                break;
            
            case PeasantState.ForwardSpikeAttack:
                stateTimer = 3f;
                break;
            
            case PeasantState.SideSpikeAttack:
                stateTimer = 3f;
                break;
        }
    }

    void ExitState(PeasantState state)
    {
        
    }
}
