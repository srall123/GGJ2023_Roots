using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    public bool all_parent_generated;
    bool player1_shot;
    bool player2_shot;
    public bool start_shot;
    public bool end_game;
    public GameObject ball;

    void Start()
    {
        Debug.Log("Roots of Petanque!");
        all_parent_generated = false;
        player1_shot = false;
        player2_shot = false;
        start_shot = false;
        end_game = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject current = Instantiate(ball, new Vector3(0,-6,0), Quaternion.identity);
            current.gameObject.name = "root";
            root.transform.scale = new Vector3(0.8f, 0.8f, 2);
            root.GetComponent<move_ball>().force = new Vector2(10,5);
        }

        // if (Input.GetKeyDown("space")
        //     && (Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
        // {
        //     player1_shot = true;
        //     ball1.SetActive(true);
        //     ball1.GetComponent<move_ball>().force = new Vector2(5,5);
        // }

        // if ((Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && ball1.transform.position.x > -5 && ball1.transform.position.x < 5
        //     && (Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
        // {
        //     player2_shot = true;
        //     ball4.SetActive(true);
        // }

        // if ((Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && ball4.transform.position.x > -5 && ball4.transform.position.x < 5
        //     && (Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
        //     ball2.SetActive(true);

        // if ((Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && ball2.transform.position.x > -5 && ball2.transform.position.x < 5
        //     && (Mathf.Abs(ball2.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball2.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
        //     ball5.SetActive(true);

        // if ((Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball2.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball2.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && ball5.transform.position.x > -5 && ball5.transform.position.x < 5
        //     && (Mathf.Abs(ball5.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball5.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
        //     ball3.SetActive(true);

        // if ((Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball2.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball2.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball3.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball3.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && ball3.transform.position.x > -5 && ball3.transform.position.x < 5
        //     && (Mathf.Abs(ball5.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball5.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
        //     {
        //         ball6.SetActive(true);
        //         all_parent_generated = true;
        //     }

        // if (all_parent_generated && (Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball2.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball2.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball3.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball3.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball5.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball5.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && ball6.transform.position.x > -5 && ball6.transform.position.x < 5
        //     && (Mathf.Abs(ball6.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball6.GetComponent<Rigidbody2D>().velocity.y)) < 0.001)
        //     {
        //         start_shot = true;
        //         all_parent_generated = false;
        //     }

        if (player1_shot)
            FindObjectOfType<GameManager>().score_calculator(1);
        if (player2_shot)
            FindObjectOfType<GameManager>().score_calculator(2);

        // if (end_game && (Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball1.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball2.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball2.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball3.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball3.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball4.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && (Mathf.Abs(ball5.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball5.GetComponent<Rigidbody2D>().velocity.y)) < 0.01
        //     && ball6.transform.position.x > -5 && ball6.transform.position.x < 5
        //     && (Mathf.Abs(ball6.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(ball6.GetComponent<Rigidbody2D>().velocity.y)) < 0.001)
        //     {
        //         FindObjectOfType<GameManager>().EndGame();
        //     }



    }
}
