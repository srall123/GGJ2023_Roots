using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_parent : MonoBehaviour
{

	public GameObject player1;
	public GameObject player2;
	public GameObject user_input;
	public GameObject root;
	public GameObject current_player;
	int i;
	public int nbr_parent;
	bool parent_generated;
	public bool all_parent_generated;
	public GameObject[] player_parents;
	bool all_stop;
	public GameObject ball1;
	public GameObject ball2;
	public GameObject ball3;

    // Start is called before the first frame update
    void Start()
    {
		i = 0;
		parent_generated = false;
		all_parent_generated = false;
		// all_stop = false;
				all_stop = true;
    }

    // Update is called once per frame
    void Update()
    {
		// if (i < nbr_parent && root.GetComponent<root>().root_shoot == true)
		if (i < nbr_parent)
		{
			// Debug.Log("Here2");
			// StartCoroutine(CheckObjectsHaveStopped());
			
			if (parent_generated == false && (Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.y)) < 0.01 && check_stop() == true)
			// if (parent_generated == false)
			{
				// if (i % 2 == 0)
				// {
					if (i != 0)
					{
						FindObjectOfType<GameManager>().score_calculator(1);
						FindObjectOfType<GameManager>().score_calculator(2);
					}
					current_player = Instantiate(player1, transform.position, Quaternion.identity);
					if (i == 0)
						ball3.SetActive(false);
					else if (i == 1)
						ball2.SetActive(false);
					else
						ball1.SetActive(false);
					user_input.GetComponent<user_input>().input_active = true;
				// }
				// else
				// {
				// 	// GetComponent<parent2>().enabled = true;
				// 	current_player = Instantiate(player2, transform.position + new Vector3(3, 0 ,0), Quaternion.identity);
				// 	user_input.GetComponent<user_input>().input_active = true;
				// }
				parent_generated = true;
			}
			if (parent_generated == true)
			{
				// Debug.Log(user_input.GetComponent<user_input>().input_chosen);
				if (user_input.GetComponent<user_input>().input_chosen == true)
				{
					// GetComponent<add_force>().force(user_input.GetComponent<user_input>().force, user_input.GetComponent<user_input>().x);   //to change
					current_player.GetComponent<add_force>().enabled = true;
					if (i < nbr_parent - 1)
					{
						user_input.GetComponent<user_input>().input_chosen = false;
						// user_input.GetComponent<user_input>().input_active = true;
					}
					if ((Mathf.Abs(current_player.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(current_player.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
					{		
						parent_generated = false;
						GetComponent<parent2>().enabled = true;
						GetComponent<generate_parent>().enabled = false;
					}
					// if (i % 2 == 0)
					// 	FindObjectOfType<GameManager>().score_calculator(1);
					// else
					// 	FindObjectOfType<GameManager>().score_calculator(2);
					i++;
				}
			}
		}
		if (i == nbr_parent)
		{
			user_input.GetComponent<user_input>().input_chosen = false;
			GetComponent<generate_parent>().enabled = false;
		// 	all_parent_generated = true;
		}
		
    }



	bool check_stop()
	{
		all_stop = true;

		player_parents = GameObject.FindGameObjectsWithTag("Player1");
		foreach (GameObject parent in player_parents)
		{
		// 	if (!((Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y)) > 0
		// 		&& (Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y)) < 0.01))
		// 		{

		// 		// Debug.Log("Player1");
		// 		all_stop = false;
		// 		}
					if (!((Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) < 0.01) && Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y) < 0.01))
			{
				all_stop = false;


			}
		}
		

		player_parents = GameObject.FindGameObjectsWithTag("Player2");
		foreach (GameObject parent in player_parents)
		{
		// 	if (!((Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y)) > 0
		// 		&& (Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y)) < 0.01))
		// 		{

		// 		// Debug.Log("Player1");
		// 		all_stop = false;
		// 		}
					if (!((Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) < 0.01) && Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y) < 0.01))
			{
				all_stop = false;


			}
		}
		return all_stop;
	}

// 	IEnumerator CheckObjectsHaveStopped()
//  	{
// 		print("checking... ");
// 		Rigidbody2D[] GOS = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
// 		bool allSleeping = false;
		
// 		while(!allSleeping)
// 		{
// 			allSleeping = true;
	
// 			foreach (Rigidbody2D GO in GOS) 
// 			{
// 			if(!GO.IsSleeping())
// 			{
// 				allSleeping = false;
// 				yield return null;
// 				break;
// 			}
// 			}
		
// 		}
// 		print("All objects sleeping");
// 		//Do somet$$anonymous$$ng else
 
//  }

	// IEnumerator CheckObjectsHaveStopped()
 	// {
	// 	all_stop = false;
	// 	player1s = GameObject.FindGameObjectsWithTag("Player1");
	// 	player2s = GameObject.FindGameObjectsWithTag("Player2");
		
	// 	while(!all_stop)
	// 	{
	// 		all_stop = true;
	// 		foreach (GameObject player1 in player1s)
	// 		{
	// 			if (!((Mathf.Abs(player1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(player1.GetComponent<Rigidbody2D>().velocity.y)) > 0
	// 				&& (Mathf.Abs(player1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(player1.GetComponent<Rigidbody2D>().velocity.y)) < 0.01))
	// 				{
	// 					all_stop = false;
	// 				}
	// 		}
	// 		foreach (GameObject player2 in player1s)
	// 		{
	// 			if (!((Mathf.Abs(player2.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(player2.GetComponent<Rigidbody2D>().velocity.y)) > 0
	// 				&& (Mathf.Abs(player2.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(player2.GetComponent<Rigidbody2D>().velocity.y)) < 0.01))
	// 				{
	// 					all_stop = false;
	// 				}
	// 		}
		
	// 	}
	// 	yield return null;
	// 	print("All objects sleeping");
	// 	//Do somet$$anonymous$$ng else
 
 	// }

 	// void check_stop()
	// {
	// 	all_stop = true;
	// 	children1 = GameObject.FindGameObjectsWithTag("Children1");
	// 	children1 = GameObject.FindGameObjectsWithTag("Children2");

	// 	// foreach (GameObject child1 in children1)
	// 	// {
	// 	// 	if (!((Mathf.Abs(child1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(child1.GetComponent<Rigidbody2D>().velocity.y)) > 0
	// 	// 		&& (Mathf.Abs(child1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(child1.GetComponent<Rigidbody2D>().velocity.y)) < 0.01))
	// 	// 		all_stop = false;
	// 	// }

	// 	// foreach (GameObject child2 in children1)
	// 	// {
	// 	// 	if (!((Mathf.Abs(child2.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(child2.GetComponent<Rigidbody2D>().velocity.y)) > 0
	// 	// 		&& (Mathf.Abs(child2.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(child2.GetComponent<Rigidbody2D>().velocity.y)) < 0.01))
	// 	// 		all_stop = false;
	// 	// }

	// 	player_parents = GameObject.FindGameObjectsWithTag("ball1");
	// 	foreach (GameObject parent in player_parents)
	// 	{
	// 		if (!((Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y)) > 0
	// 			&& (Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y)) < 0.01))
	// 			{

	// 			Debug.Log("Ball1");
	// 			all_stop = false;
	// 			}
	// 	}

	// 	player_parents = GameObject.FindGameObjectsWithTag("ball2");
	// 	foreach (GameObject parent in player_parents)
	// 	{
	// 		if (!((Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y)) > 0
	// 			&& (Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y)) < 0.01))
	// 			{
	// 				Debug.Log("Ball2");
	// 				all_stop = false;
	// 			}
	// 	}
	// }
}
