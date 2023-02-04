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
	public bool all_parent_generated;
    public bool end_game;
	bool player1_shot;
	bool player2_shot;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Roots of Petanque!");
        root.SetActive(true);
		all_parent_generated = false;
        end_game = false;
        player1_shot = false;
        player2_shot = false;
    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.GetComponent<AudioSource>().Play();
        if (root.transform.position.x != 0 && root.transform.position.y != -6
            && root.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f)
        {
            ball1.SetActive(true);
            player1_shot = true;
        }
        if (ball1.transform.position.x != 0 && ball1.transform.position.y != -6
            && ball1.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f)
        {
            ball4.SetActive(true);
            player2_shot = true;
        }
        if (ball4.transform.position.x != 0 && ball4.transform.position.y != -6
            && ball4.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f)
            ball2.SetActive(true);
        if (ball2.transform.position.x != 0 && ball2.transform.position.y != -6
            && ball2.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f)
            ball5.SetActive(true);

        if (ball5.transform.position.x != 0 && ball5.transform.position.y != -6
            && ball5.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f)
            ball3.SetActive(true);
        if (ball3.transform.position.x != 0 && ball3.transform.position.y != -6
            && ball3.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f)
            ball6.SetActive(true);

        if (ball3.transform.position.x != 0 && ball3.transform.position.y != -6
            && ball1.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f && ball2.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f
            && ball3.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f && ball4.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f
            && ball5.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f && ball6.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f)
            {
                all_parent_generated = true;
            }

        if (player1_shot)
            FindObjectOfType<GameManager>().score_calculator(1);
        if (player2_shot)
            FindObjectOfType<GameManager>().score_calculator(2);
        if (end_game && all_parent_generated)
            FindObjectOfType<GameManager>().EndGame();
    }

}
