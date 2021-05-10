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

        private void Awake()
        {
            stats = GetComponent<CharacterStats>();
            agent = GetComponent<NavMeshAgent>();
        }

        void Start()
        {
            agent.stoppingDistance = GetComponent<MobController>().attackDistance;
        }

        public void Move(Vector3 targetPosition)
        {
            agent.speed = stats.speed.GetStat();
            agent.SetDestination(targetPosition);
        }

        public void Walk(Vector3 targetPosition)
        {
            agent.speed = stats.speed.GetStat() * 0.7f;
            agent.SetDestination(targetPosition);
        }
        
        public void SetPosition(Vector3 position)
        {
            agent.Warp(position);
        }

        public void StopAgent()
        {
            agent.enabled = false;
        }
    }
}