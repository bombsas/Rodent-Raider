using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMechanics : MonoBehaviour
{
    [SerializeField] private float cam_speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    private void update()
    {
        transform.position = Vector3.SmoothDamp( transform.positon, new Vector3(currentPosX, transform.position.y, transform.position.z), velocity, cam_speed * Time.deltaTime );
    }

    public void MoveToNewRoom()
    {
        
    }
}
