using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityTimer;
using Random = UnityEngine.Random;

public class Pet : MonoBehaviour
{
    public PetState state;
    public Room room;

    public float walkSpeed;
    public float idleTimeMin, idleTimeMax;

    private void Start()
    {
        SetState(PetState.RandomWalk);
    }

    public void SetState(PetState state)
    {
        this.state = state;
        
        switch (state)
        {
            case PetState.Idle:

                Timer.Register(Random.Range(idleTimeMin, idleTimeMax), () => SetState(PetState.RandomWalk));
                
                break;
            
            case PetState.RandomWalk:
                
                WayPoint point = room.GetRandomFreeWalkPoint();
                if (point == null)
                {
                    SetState(PetState.Idle);
                    return;
                }
                
                point.isFree = false;
                transform.DOMove(
                    point.position.position, walkSpeed * Vector3.Distance(transform.position, point.position.position))
                    .SetEase(Ease.Linear).OnComplete(() =>
                    {
                        SetState(PetState.Idle);
                        point.isFree = true;
                    });
                break;
            
            case PetState.Sleep:
                
                break;
            case PetState.Starvation:
                
                break;
        }
    }

    public void StateUpdater()
    {
        switch (state)
        {
            case PetState.Idle:
                
                break;
            case PetState.RandomWalk:
                
                break;
            case PetState.Sleep:
                
                break;
            case PetState.Starvation:
                
                break;
        }
    }
}

[System.Serializable]
public class Parameters
{
    public float Hunger = 0;
    
}

public enum PetState
{
    Idle,
    RandomWalk,
    Sleep,
    Starvation
}