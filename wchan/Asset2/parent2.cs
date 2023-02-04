using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parent2 : MonoBehaviour
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


    // Start is called before the first frame update
    void Start()
    {
		i = 0;
		parent_generated = false;
		all_parent_generated = false;
		all_stop = true;
    }

    // Update is called once per frame
    void Update()
    {
		// if (i < nbr_parent && root.GetComponent<root>().root_shoot == true)
		if (i < nbr_parent)
		{
			// Debug.Log(i);
			// StartCoroutine(CheckObjectsHaveStopped());
			
			if (parent_generated == false && (Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.y)) < 0.01 && check_stop() == true)
			// if (parent_generated == false)
			{
				// if (i % 2 == 0)
				// {
					// current_player = Instantiate(player1, transform.position + new Vector3(-3, 0, 0), Quaternion.identity);
					// user_input.GetComponent<user_input>().input_active = true;
				// }
				// else
				// {
				// 	// GetComponent<parent2>().enabled = true;
					current_player = Instantiate(player2, transform.position, Quaternion.identity);
					user_input.GetComponent<user_input>().input_active = true;
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
						GetComponent<generate_parent>().enabled = true;
						GetComponent<parent2>().enabled = false;
						i++;
					}
					if (i % 2 == 0)
						FindObjectOfType<GameManager>().score_calculator(1);
					else
						FindObjectOfType<GameManager>().score_calculator(2);
				}
			}
		}
		if (i == nbr_parent && check_stop() == true)
		{
			user_input.GetComponent<user_input>().input_chosen = false;
			all_parent_generated = true;
		}
		
    }

	 	bool check_stop()
	{
		all_stop = true;

		player_parents = GameObject.FindGameObjectsWithTag("Player1");
		foreach (GameObject parent in player_parents)
		{
			// if (!((Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y)) > 0
			// 	&& (Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y)) < 0.01))
			// 	{

			// 	// Debug.Log("Player1");
			// 	all_stop = false;
			// 	}
			if (!((Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) < 0.01) && Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y) < 0.01))
			{
				all_stop = false;


			}
		}

		player_parents = GameObject.FindGameObjectsWithTag("Player2");
		foreach (GameObject parent in player_parents)
		{
			if (!((Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) < 0.01) && Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y) < 0.01))
			{
				all_stop = false;


			}
		}
		return all_stop;
	}




}
