using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class BlockBehavior : MonoBehaviour
{
    [SerializeField] GameObject TeleRepere;
    private GameObject _TeleVisor;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private LineRenderer lr;


    [NonSerialized] public bool isHovered;
    private bool isSelected;
    [NonSerialized] public int objectsColliding;

    private void Awake()
    {
        
    }

    void Update()
    {
        _TeleVisor = TeleVisor.VisorInstance.gameObject;

        if (isHovered && Input.GetMouseButtonDown(1) && !General.isBlockSeleted)
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

        if (Input.GetMouseButtonUp(0))
        {
            Deselected();
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

    private void Deselected()
    {
        TeleRepere.transform.position = transform.position;
        TeleRepere.transform.rotation = transform.rotation;
        isSelected = false;
    }
}