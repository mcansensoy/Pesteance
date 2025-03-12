using UnityEngine;
using Cinemachine;

public class CameraController : Singleton<CameraController>
{
    [SerializeField] private GameObject player_c;
    private CinemachineVirtualCamera cinemachine_VCam;

    private void Start()
    {
        // Find the player GameObject by tag or assign it directly in the Inspector
        //player_c = GameObject.FindWithTag("Player"); 

        Set_PlayerCamera_Follow();
    }

    public void Set_PlayerCamera_Follow()
    {
        cinemachine_VCam = FindObjectOfType<CinemachineVirtualCamera>();

       // cinemachine_VCam.Follow = Player.Instance_T.transform;


        // Assign the player's transform to the CinemachineVirtualCamera's Follow property
        cinemachine_VCam.Follow = player_c.transform;
    }
}
