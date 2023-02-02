using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject root;
    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;
    public GameObject ball4;
    public GameObject ball5;
    public GameObject ball6;

    void Hide()
    {
        root.SetActive(false);
        ball1.SetActive(false);
        ball2.SetActive(false);
        ball3.SetActive(false);
        ball4.SetActive(false);
        ball5.SetActive(false);
        ball6.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Roots of Petanque!");
        root.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.GetComponent<AudioSource>().Play();
        if ((Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
            ball1.SetActive(true);

        if ((Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.y)) > 0
            && (Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
            ball2.SetActive(true);

        if ((Mathf.Abs(ball2.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball2.GetComponent<Rigidbody2D>().velocity.y)) > 0
            && (Mathf.Abs(ball2.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball2.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
            ball3.SetActive(true);

        if ((Mathf.Abs(ball3.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball3.GetComponent<Rigidbody2D>().velocity.y)) > 0
            && (Mathf.Abs(ball3.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball3.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
            ball4.SetActive(true);

        if ((Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.y)) > 0
            && (Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
            ball5.SetActive(true);

        if ((Mathf.Abs(ball5.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball5.GetComponent<Rigidbody2D>().velocity.y)) > 0
            && (Mathf.Abs(ball5.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball5.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
            ball6.SetActive(true);

        if ((Mathf.Abs(ball6.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball6.GetComponent<Rigidbody2D>().velocity.y)) > 0
            && (Mathf.Abs(ball6.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball6.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
            Debug.Log("Game Over!");

    }
}
