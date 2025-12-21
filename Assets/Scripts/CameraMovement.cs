using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float Distance = 5;
    public float DistanceV = 3;

    void Update()
    {
        if (TeleVisor.VisorInstance.gameObject.transform.position.x >= transform.position.x + Distance)
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }
        if (TeleVisor.VisorInstance.gameObject.transform.position.x <= transform.position.x - Distance)
        {
            transform.position += new Vector3(-0.1f, 0, 0);
        }
        if (TeleVisor.VisorInstance.gameObject.transform.position.y >= transform.position.y + DistanceV)
        {
            transform.position += new Vector3(0, 0.1f, 0);
        }
        if (TeleVisor.VisorInstance.gameObject.transform.position.y <= transform.position.y - DistanceV)
        {
            transform.position += new Vector3(0, -0.1f, 0);
        }
    }
}
