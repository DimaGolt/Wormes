using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField]
    bool isBouncing;
    bool onGround;
    bool isJumping;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        rigidbody.velocity += new Vector2(movement, 0);
        if (Input.GetKey(KeyCode.UpArrow) && onGround && !isJumping)
        {
            isJumping = true;
            Invoke(nameof(Jump), 1f);
        }
    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Wall")
        {
            float bounce = 600f; //amount of force to apply
            rigidbody.AddForce(collision.contacts[0].normal * bounce);
            isBouncing = true;
            Invoke("StopBounce", 1f);
        }
        if (collision.gameObject.tag == "Floor")
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onGround = false;
        }
    }

    void StopBounce()
    {
        isBouncing = false;
    }

    void Jump() {
        rigidbody.AddForce(new Vector2(0, 500));
        isJumping = false;
    }
}
