using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ball : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 force;
    public AudioClip[] audios;

    void modify_physics(Rigidbody2D rb)
    {
        if ((Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)) < 1)
            rb.drag = 5;
        else if ((Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)) < 0.1)
            rb.drag = 100;
        else
            rb.drag = 0.35f;
        if (Mathf.Abs(rb.angularVelocity) < 20)
            rb.angularDrag = 10;
        else
            rb.angularDrag = 0.35f;
    }

    void Start()
    {
        Debug.Log("Active the Ball!");
        rb = gameObject.GetComponent<Rigidbody2D>();
        // force = new Vector2(3, 10);// this is a Vector provide by Sumin
    }

    void Update()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        modify_physics(rb);
        if (force.x != 0 && force.y != 0)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
            rb.GetComponent<AudioSource>().Play();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        this.GetComponent<AudioSource>().Play();
    }
}
