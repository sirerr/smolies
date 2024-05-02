using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    Rigidbody rb;
    public float movespeed = 5f;
    Vector2 movedirection;
    public InputActionReference move;
    public InputActionReference fire;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movedirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movedirection.x * movespeed, movedirection.y * movespeed);
    }

    private void OnEnable()
    {
        fire.action.started += Fired;
    }

    private void OnDisable()
    {
        fire.action.started -= Fired;
    }

    private void Fired(InputAction.CallbackContext obj)
    {
        print("fired");
    }
}
