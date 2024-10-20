using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _compRigidbody2D;
    float horizontal;
    float vertical;
    [SerializeField] float speed;

    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(speed * horizontal, speed * vertical);
    }
}
