using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float radius = 2;

    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 v = _rb.velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Initialize(int power, Vector3 vector)
    {
        _rb.AddForce(vector * (power/2), ForceMode2D.Impulse);
    }

    void Explode()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject explosion = Instantiate(explosionPrefab, _rb.position, Quaternion.identity);
        Explode();
    }
}
