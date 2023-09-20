using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpikes : MonoBehaviour
{
    [SerializeField] private float spikesDamage;
    private Health health;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().takeDamage(spikesDamage);
        }
    }
}
