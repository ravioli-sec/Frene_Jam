using UnityEngine;

public class Spin : MonoBehaviour
{
    public float Speed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, Speed));
    }
}
