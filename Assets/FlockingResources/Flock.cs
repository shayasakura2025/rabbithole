﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behavior;

    [Range(0,50)]
    public int startingCount = 1;
    const float AgentDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;

    [Range(1f,10f)]
    public float neighborRadius = 1.5f;
    [Range(0f,1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius {get {return squareAvoidanceRadius;}}

    [SerializeField] public GameObject playerRef;
    public int bunCount = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++){
            bunCount += 1;
            InstantiateNewBun(bunCount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(FlockAgent agent in agents){
            List<Transform> context = GetNearbyObjects(agent);
            Vector2 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            if(move.sqrMagnitude > squareMaxSpeed){
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent agent){
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);

        foreach(Collider2D c in contextColliders){
            if (c != agent.AgentCollider){
                context.Add(c.transform);
            }
        }

        return context;
    }

    public void AddBunny() {
        InstantiateNewBun(bunCount);
        bunCount++;
    }

    void InstantiateNewBun(int bunCount) {
        FlockAgent newAgent = Instantiate(
                agentPrefab,
                UnityEngine.Random.insideUnitCircle * startingCount * AgentDensity,
                Quaternion.Euler(Vector3.forward * UnityEngine.Random.Range(0f,360f)),
                transform
            );
            newAgent.name = "Agent " + bunCount;
            newAgent.Initialize(this);
            agents.Add(newAgent);
            if (bunCount < 4)
            {
                newAgent.GetComponentInChildren<FlockAnimatedSound>().canJump = true;
            }
    }
}
