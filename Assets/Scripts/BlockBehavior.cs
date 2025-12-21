using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BlockBehavior : MonoBehaviour
{
    [SerializeField] GameObject TeleRepere;
    [SerializeField] GameObject _TeleVisor;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private LineRenderer lr;


    private bool isHovered;
    private bool isSelected;
    private int objectsColliding;

    private void Awake()
    {
        _TeleVisor.GetComponent<TeleVisor>().released.AddListener(Deselected);
    }

    void Update()
    {
        if (isHovered && Input.GetMouseButtonDown(1))
        {
            isSelected = true;
            General.isBlockSeleted = true;
        }

        if (isSelected)
        {
            TeleRepere.transform.position = _TeleVisor.transform.position;
            TeleRepere.transform.rotation = _TeleVisor.transform.rotation;

            if(Input.GetMouseButtonDown(1) && objectsColliding == 0)
            {
                transform.position = TeleRepere.transform.position;
                transform.rotation = TeleRepere.transform.rotation;
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0;
            }
        }

        if(objectsColliding != 0)
        {
            sr.color = Color.red;
            sr.color -= new Color(0f, 0f, 0f, 0.5f);
        }
        else
        {
            sr.color = Color.cyan;
            sr.color -= new Color(0f, 0f, 0f, 0.5f);
        }

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, TeleRepere.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && General.isTeleporting)
        {
            isHovered = true;
        }

        if(collision.tag != "Player")
        {
            objectsColliding += 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player" && General.isTeleporting)
        {
            isHovered = false;
        }

        if (collision.tag != "Player")
        {
            objectsColliding -= 1;
        }
    }

    private void Deselected()
    {
        TeleRepere.transform.position = transform.position;
        TeleRepere.transform.rotation = transform.rotation;
        isSelected = false;
    }
}