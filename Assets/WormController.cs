using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        rigidbody.velocity += new Vector2(movement, 0);
    }
}
