using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DASH._Units
{
    public class MobMovement : MonoBehaviour
    {
        NavMeshAgent agent;
        float timer;
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            if(timer < 0)
            {
                Vector3 randomTarget = new Vector3(UnityEngine.Random.Range(-4, 4), 0, UnityEngine.Random.Range(-4, 4));
                Move(randomTarget);
                timer = 5f;
            }
            timer -= Time.deltaTime;
            if (!agent.hasPath)
            {
            }
        }

        public void Move(Vector3 targetPosition)
        {
            Debug.Log("I'm moving to " + targetPosition);
            agent.SetDestination(targetPosition);
        }
    }
}