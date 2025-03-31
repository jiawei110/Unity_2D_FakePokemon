using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(player.position.x, player.position.y, this.transform.position.z); ; // Camera follows the player but 6 to the right 
    }
}
