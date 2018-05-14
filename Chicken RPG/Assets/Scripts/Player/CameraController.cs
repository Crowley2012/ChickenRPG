using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    private Vector3 _cameraDistance;

    void Start()
    {
        //Set the distance of the camera from player
        _cameraDistance = transform.position - Player.transform.position;
    }

    void LateUpdate()
    {
        //Set the camera position to where the player is
        transform.position = Player.transform.position + _cameraDistance;
    }
}
