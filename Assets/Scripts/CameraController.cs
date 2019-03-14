using UnityEngine;
using UnityEngine.Networking;

public class CameraController : NetworkBehaviour
{
    private void Start()
    {
        if (!isServer) return;
        transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1f));
    }
}