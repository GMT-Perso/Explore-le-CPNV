using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]private GameObject player;

    // Update is called once per frame
    void Update()
    {
        //We move the camera at the position of the player with an offset.
        transform.position = player.transform.position + new Vector3(0, 8, 0);
    }
}
