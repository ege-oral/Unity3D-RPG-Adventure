using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public float attackDelay = 0.6f;

    public event System.Action OnAttack;

    CharacterStats myStats;

    private void Start() 
    {
        myStats = GetComponent<CharacterStats>();    
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if(attackCooldown <= 0f)
        {
            StartCoroutine(DoDamge(targetStats, attackDelay));

            if(OnAttack != null)
                OnAttack();

            attackCooldown = 1f / attackSpeed;
        }
    }

    IEnumerator DoDamge(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
    }
}
