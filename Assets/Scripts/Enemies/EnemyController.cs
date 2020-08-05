using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float radius = 30f;
    public int health = 40;
    public int damage = 10;
    public float attackDelay = 0.5f;
    public float attackCooldown = 1.5f;
    public float afterShoveCooldown = 0.5f;
    [Tooltip("0 - 100 | Reduces chance to cancel attack")]
    public int toughness;
    [Tooltip("Debug only")]
    public AnimationClip attackAnimation;

    private NavMeshAgent agent;
    private Transform playerTransform;
    private PlayerController playerController;
    private bool isAlive = true;
    private float checkTime = 0.1f;
    private float lastAttackTime = 0;
    private bool isAttacking = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameManager.instance.player.transform;
        playerController = GameManager.instance.player.GetComponent<PlayerController>();
        StartCoroutine("ProximityCheck");
    }

    public void TakeDamage(int damage, int chanceToCancelAttack)
    {
        health -= damage;
        Debug.Log(health);

        // Checking if attack from player canceled enemy attack
        if (isAttacking)
        {
            Debug.Log(chanceToCancelAttack);
            float chance = (float)(chanceToCancelAttack * (100 - toughness)) / 10000;
            float random = Random.value;
            if (random <= chance)
                isAttacking = false;
            Debug.Log(new Vector2(random, chance));
        }
        if (health <= 0)
        {
            // Ragdoll?
            Destroy(this.gameObject);
        }
    }

    public void TakeShove(Vector3 direction)
    {
        agent.Move(direction); //todo: fluent movement
        agent.isStopped = true;
        isAttacking = false;
        StartCoroutine(AgentCooldownAfterShove());
    }

    #region Coroutines
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
                    if (lastAttackTime + attackCooldown < Time.time && !isAttacking)
                    {
                        StartCoroutine(Attack());
                    }

                    transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));
                }
                distance = Vector3.Distance(transform.position, playerTransform.position);
                yield return null;
            }
            yield return new WaitForSeconds(checkTime);
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        lastAttackTime = Time.time;
        // Play animation
        yield return new WaitForSeconds(attackDelay);
        
        lastAttackTime = Time.time;
        if (isAttacking)
        {
            playerController.TakeDamage(damage);
            isAttacking = false;
        }
        else
        {
            Debug.Log("Attack canceled");
        }

    }

    IEnumerator AgentCooldownAfterShove()
    {
        yield return new WaitForSeconds(afterShoveCooldown);
        agent.isStopped = false;
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
