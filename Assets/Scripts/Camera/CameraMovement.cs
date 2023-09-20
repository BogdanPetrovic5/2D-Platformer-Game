using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]private float cameraSpeed;
    [SerializeField] private float LevelX;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, cameraSpeed);  
    }
    public void MoveToNewRoom(float newPosX, float offset)
    {
        print(newPosX);
        currentPosX = newPosX - offset;
    }
}
