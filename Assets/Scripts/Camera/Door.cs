using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]private Transform previousArea;
    [SerializeField]private Transform nextArea;
    [SerializeField]private CameraMovement camera;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            print("Sudar");
            if(collision.transform.position.x < transform.position.x)
            {
                print("Sudar s leve");
                print(nextArea.transform.position.x);
                camera.MoveToNewRoom(nextArea.transform.position.x, nextArea.parent.transform.position.x);
            }else{
                print("Sudar s desne");
                print("Prva" + previousArea.transform.position.x);
                camera.MoveToNewRoom(previousArea.transform.position.x, previousArea.parent.transform.position.x);
            }
        }
    }
}
