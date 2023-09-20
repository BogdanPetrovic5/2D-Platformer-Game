using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Animations;

public class MoveSaw : MonoBehaviour
{

    [SerializeField] private float SawSpeed;
    [SerializeField]private float SawDamage;
    private float distance;
    private float parentLeft;
    private float parentRight;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider2D;
    private bool moveLeft = true;
    private bool moveRight = false;
    // Update is called once per frame
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        Transform parentTransform = transform.parent;
        parentRight = (parentTransform.GetComponent<BoxCollider2D>().size.x / 2) + transform.parent.position.x;
        parentLeft = Mathf.Abs((parentTransform.GetComponent<BoxCollider2D>().size.x / 2) - transform.parent.position.x);
        
    }
    void Update()
    {
        if (transform.position.x >= parentLeft && moveLeft == true)
        {
            
            body.velocity = new Vector2(-SawSpeed, body.velocity.y);

        }
        else moveLeft = false;
        if (transform.position.x <= parentRight && moveLeft == false)
        {
            body.velocity = new Vector2(SawSpeed, body.velocity.y);
        }
        else moveLeft = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().takeDamage(SawDamage);
        }
    }
}
