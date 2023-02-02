using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_root : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 force;
    public AudioClip[] audio;
    // Vector2 inputPos;

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
        Debug.Log("Active the Root!");
        rb = gameObject.GetComponent<Rigidbody2D>();
        force = new Vector2(20, 10);// this is a Vector provide by Sumin
        rb.AddForce(force, ForceMode2D.Impulse);
        rb.GetComponent<AudioSource>().clip = audio[0];
        rb.GetComponent<AudioSource>().volume = 0.3f;
        rb.GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        // inputPos.x = Input.GetAxis("Horizontal");
        // inputPos.y = Input.GetAxis("Vertical");
        // rb.AddForce(inputPos * movespeed, ForceMode2D.Impulse);
        modify_physics(rb);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        rb.GetComponent<AudioSource>().clip = audio[1];
        rb.GetComponent<AudioSource>().volume = 1;
        this.GetComponent<AudioSource>().Play();
    }
}
