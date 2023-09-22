using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkeletonHealthBar : MonoBehaviour
{
    private GameObject Health;
    private GameObject Enemy;
    private SpriteRenderer lastChildSrpite;
    private int healthCounter;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        healthCounter = 1;
        Health = GameObject.Find("EnemyHealth");
        Enemy = GameObject.Find("Enemy");
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    public void takeDamage()
    {
        StartCoroutine(ExecuteAfterDelay());
       
        


    }
    private IEnumerator ExecuteAfterDelay()
    {
        print("DDD");
        yield return new WaitForSeconds(0.5f);
        Transform lastChild = transform.GetChild(transform.childCount - healthCounter);
        lastChild.GetComponent<SpriteRenderer>().enabled = false;
        Enemy.GetComponent<EnemyAttack>().hurt();
        if (healthCounter == 3)
        {
            Enemy.GetComponent<EnemyAttack>().die();
            Enemy.GetComponent<EnemyAttack>().enabled = false;
        }
        healthCounter += 1;
    }
}
