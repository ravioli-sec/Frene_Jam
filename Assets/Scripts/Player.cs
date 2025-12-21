using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private GameObject TeleVisor;
    private Rigidbody2D rb;
    private InputSystem_Actions action;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        action = new InputSystem_Actions();
        action.Enable();
        VisorInstanciate();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        var Raycast = Physics2D.Raycast(transform.position, Vector2.down, 0.55f);
        if (action.Player.Move.IsPressed() && !General.isTeleporting)
        {
            transform.position += new Vector3(action.Player.Move.ReadValue<Vector2>().x * speed , 0f, 0f);
        }
        if (action.Player.Jump.triggered && Raycast && !General.isTeleporting)
        {
            rb.AddForce(new Vector2 (0f, jumpSpeed));
        }
        if (action.Player.Attack.IsPressed() && Raycast)
        {
            TeleVisor.SetActive(true);
            General.isTeleporting = true;
        }
        else
        {
            TeleVisor.SetActive(false);
            General.isTeleporting = false;
            General.isBlockSeleted = false;
            TeleVisor.transform.position = transform.position;
            TeleVisor.transform.rotation = transform.rotation;
        }
    }

    private IEnumerator VisorInstanciate()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        TeleVisor.SetActive(false);
    }
}