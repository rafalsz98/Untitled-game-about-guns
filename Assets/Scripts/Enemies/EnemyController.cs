using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float radius = 30f;
    public float health = 40f;

    private NavMeshAgent agent;
    private Transform playerTransform;
    private bool isAlive = true;
    private float checkTime = 0.1f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameManager.instance.player.transform;
        StartCoroutine("ProximityCheck");
    }

    IEnumerator ProximityCheck()
    {
        while (isAlive)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            while (distance <= radius)
            {
                agent.SetDestination(playerTransform.position);
                if (distance <= agent.stoppingDistance)
                {
                    // Attack

                    transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));
                }
                distance = Vector3.Distance(transform.position, playerTransform.position);
                yield return null;
            }
            yield return new WaitForSeconds(checkTime);
        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
