using UnityEngine;
using Cinemachine;

public class CameraFollow_ : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;  // Reference to the virtual camera

    private void Start()
    {
        FindPlayerObject();
    }

    private void FindPlayerObject()
    {
        // Find the player object in the scene
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null && virtualCamera != null)
        {
            // Set the virtual camera's follow target to the player object
            virtualCamera.Follow = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player object not found!");
        }
    }
}
