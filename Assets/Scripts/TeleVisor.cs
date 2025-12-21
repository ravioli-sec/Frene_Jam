using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TeleVisor : MonoBehaviour
{
    public static TeleVisor VisorInstance;

    [SerializeField] private float speed;
    private InputSystem_Actions action;

    private void Awake()
    {
        VisorInstance = this;
    }

    void OnEnable()
    {
        action = new InputSystem_Actions();
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
    void Update()
    {
        var objective = new Vector3(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x, Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y, 0f);

        var direction = objective - transform.position;

        if(Vector3.Distance(transform.position, objective) > 0.02f)
        {
            transform.position += direction.normalized * speed;
        }

        if (action.Player.Move.IsPressed() && General.isTeleporting && General.isBlockSeleted)
        {
            transform.Rotate(new Vector3(0, 0, action.Player.Move.ReadValue<Vector2>().x));
        }
    }
}
