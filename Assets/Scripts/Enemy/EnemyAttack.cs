using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float enemyDamage;
    private Animator animator;
    [SerializeField] public float progressThreshold;
    GameObject Player;
    private bool animEnded = false;
    private Health health;
    public bool isTouching;
    // Update is called once per frame
    private void Awake()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.Find("Player");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("attack");
            isTouching = true;
            
            
            StartCoroutine(ExecuteAfterDelay());
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouching = false;
        }
    }
    public void die()
    {
        animator.SetTrigger("die");
    }
    public void hurt()
    {
        animator.SetTrigger("hurt");
    }
    private IEnumerator ExecuteAfterDelay()
    {
        yield return new WaitForSeconds(0.8f);
        if (isTouching)
        {
            
            Player.GetComponent<Health>().takeDamage(enemyDamage);
        }
       
        
       
        
        

    }
}
