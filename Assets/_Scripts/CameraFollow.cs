using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // The player's Transform that the camera should follow.
    public float smoothSpeed = 10f; // Adjust the speed at which the camera follows the player.
    public Vector3 offset = new Vector3(0, 2, -10); // Adjust the camera's offset position.

    void LateUpdate()
    {
        if (target == null)
            return; // Ensure there's a valid target to follow.

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Adjust the Y position to follow the target slightly.
        float newY = Mathf.Lerp(transform.position.y, target.position.y + offset.y, 0.5f * smoothSpeed * Time.deltaTime);

        transform.position = new Vector3(smoothedPosition.x, newY, smoothedPosition.z);
    }
}
