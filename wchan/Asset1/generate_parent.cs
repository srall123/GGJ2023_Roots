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
	bool all_stop;
	public GameObject[] player1s;
	public GameObject[] player2s;

    // Start is called before the first frame update
    void Start()
    {
		i = 0;
		parent_generated = false;
		all_parent_generated = false;
		all_stop = false;

    }

    // Update is called once per frame
    void Update()
    {
		// if (i < nbr_parent && root.GetComponent<root>().root_shoot == true)
		if (i < nbr_parent)
		{
			// Debug.Log("Here2");
			StartCoroutine(CheckObjectsHaveStopped());
			// if (parent_generated == false && (Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
			if (parent_generated == false)
			{
				if (i % 2 == 0)
					current_player = Instantiate(player1, transform.position, Quaternion.identity);
				else
					current_player = Instantiate(player2, transform.position, Quaternion.identity);
				parent_generated = true;
			}
			if (parent_generated == true)
			{
				Debug.Log(user_input.GetComponent<user_input>().input_chosen);
				if (user_input.GetComponent<user_input>().input_chosen == true)
				{
					// GetComponent<add_force>().force(user_input.GetComponent<user_input>().force, user_input.GetComponent<user_input>().x);   //to change
					current_player.GetComponent<add_force>().enabled = true;
					if (i < nbr_parent - 1)
					{
						user_input.GetComponent<user_input>().input_chosen = false;
						user_input.GetComponent<user_input>().input_active = true;
					}
					parent_generated = false;
					if (i % 2 == 0)
						FindObjectOfType<GameManager>().score_calculator(1);
					else
						FindObjectOfType<GameManager>().score_calculator(2);
					i++;
				}
			}
		}
		if (i == nbr_parent)
		{
			user_input.GetComponent<user_input>().input_chosen = false;
			all_parent_generated = true;
		}
		
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

	IEnumerator CheckObjectsHaveStopped()
 	{
		all_stop = false;
		player1s = GameObject.FindGameObjectsWithTag("Player1");
		player2s = GameObject.FindGameObjectsWithTag("Player2");
		
		while(!all_stop)
		{
			all_stop = true;
			foreach (GameObject player1 in player1s)
			{
				if (!((Mathf.Abs(player1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(player1.GetComponent<Rigidbody2D>().velocity.y)) > 0
					&& (Mathf.Abs(player1.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(player1.GetComponent<Rigidbody2D>().velocity.y)) < 0.01))
					{
						all_stop = false;
					}
			}
			foreach (GameObject player2 in player1s)
			{
				if (!((Mathf.Abs(player2.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(player2.GetComponent<Rigidbody2D>().velocity.y)) > 0
					&& (Mathf.Abs(player2.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(player2.GetComponent<Rigidbody2D>().velocity.y)) < 0.01))
					{
						all_stop = false;
					}
			}
		
		}
		yield return null;
		print("All objects sleeping");
		//Do somet$$anonymous$$ng else
 
 	}

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
