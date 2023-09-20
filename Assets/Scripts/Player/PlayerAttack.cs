using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private float attackCooldown;
    private Animator animator;
    private NewBehaviourScript playerMovement;
    private float cooldown = Mathf.Infinity;
    GameObject Skeleton;
    GameObject SkeletonHealth;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<NewBehaviourScript>();
        Skeleton = GameObject.Find("Enemy");
        SkeletonHealth = GameObject.Find("EnemyHealth");
    }
    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldown > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }
        cooldown += Time.deltaTime;
    }
    private void Attack()
    {
        animator.SetTrigger("attack");
        if (Skeleton.GetComponent<EnemyAttack>().isTouching)
        {
            SkeletonHealth.GetComponent<SkeletonHealthBar>();
        }
        cooldown = 0;
    }
}
