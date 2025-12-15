using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TeleVisor : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        var objective = new Vector3(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x, Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y, 0f);

        var direction = objective - transform.position;

        if(Vector3.Distance(transform.position, objective) > 0.02f)
        {
            transform.position += direction.normalized * speed;
        }
    }
}
