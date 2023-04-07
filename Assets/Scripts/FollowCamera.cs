using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField]
    private Transform playerRef; // Reference of the player
    private void LateUpdate() {
        Vector3 targetPosition = playerRef.position;
        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        
    }
}
