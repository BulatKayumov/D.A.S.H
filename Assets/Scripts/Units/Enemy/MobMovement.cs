using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DASH._Units
{
    public class MobMovement : MonoBehaviour
    {
        NavMeshAgent agent;
        CharacterStats stats;
        void Start()
        {
            stats = GetComponent<CharacterStats>();
            agent = GetComponent<NavMeshAgent>();
            agent.stoppingDistance = GetComponent<MobController>().attackDistance;
        }

        void Update()
        {

        }

        public void Move(Vector3 targetPosition)
        {
            agent.speed = stats.speed.GetStat();
            Debug.Log("I'm moving to " + targetPosition);
            agent.SetDestination(targetPosition);
        }

        public void Walk(Vector3 targetPosition)
        {
            agent.speed = stats.speed.GetStat() * 0.7f;
            Debug.Log("I'm walking to " + targetPosition);
            agent.SetDestination(targetPosition);
        }
    }
}