using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator animator;
    private bool dead = false;
    void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth > 0) {
            animator.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                animator.SetTrigger("die");
                GetComponent<NewBehaviourScript>().enabled = false;
                dead = true;
            }
           
        }
        
    }
    private void Update()
    {
       
    }
}
