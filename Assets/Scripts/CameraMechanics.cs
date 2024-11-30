using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMechanics : MonoBehaviour
{
    [SerializeField] private float cam_speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //follow player
    [SerializeField] private Transform player;

    private void update()
    {
        //room camera
        //transform.position = Vector3.SmoothDamp( transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, cam_speed * Time.deltaTime );
        //follow player
        transform.position = new Vector3(player.position.x, transform.position.y,transform.position.z);

    }

    public void MoveToNewRoom(Transform _newRoom)
    {

    }
}
