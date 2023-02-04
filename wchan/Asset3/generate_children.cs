using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_children : MonoBehaviour
{
	public GameObject range;
	public GameObject space;
	public GameObject childen1;
	public GameObject childen2;
	public int nbr_children;
	private int i;
	public GameObject start_point;
	public GameObject[] player_parents;
	public GameObject[] ranges;
	public GameObject[] spaces;
	bool player_range_generated;
	bool children_chosen;
	public GameObject current_player;
	public GameObject user_input;
	bool valid_hit;
	bool all_stop;
	public GameObject[] children1;
	public GameObject[] children2;
	public GameObject[] parent1s;
	public GameObject[] parent2s;
	public GameObject root;




    // Start is called before the first frame update
    void Start()
    {
		player_range_generated = false;
		children_chosen = false;
		i = 0;
		all_stop = true;
    }

    // Update is called once per frame
    void Update()
    {
		if (start_point.GetComponent<parent2>().all_parent_generated == true && check_stop() == true)
		{
			if (i < nbr_children)
			{
				if (player_range_generated == false && children_chosen == false && check_stop() == true)
				{
					// if (i % 2 == 0)
						player_parents = GameObject.FindGameObjectsWithTag("Player1");
					// else
					// 	player_parents = GameObject.FindGameObjectsWithTag("Player2");
					foreach (GameObject parent in player_parents)
					{
						Instantiate(range, parent.transform.position, Quaternion.identity);
						Instantiate(space, parent.transform.position, Quaternion.identity);
					}
					player_range_generated = true;	
					children_chosen = true;
				}
				if (player_range_generated == true)
				{
					if (Input.GetMouseButtonDown(0) && check_stop() == true)
					{
						valid_hit = true;
						RaycastHit2D[] hit = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), Vector2.zero);
						if (hit.Length != 0)
						{
							for (int i = 0; i < hit.Length; ++i)
							{
								if (hit[i].collider.gameObject.tag != "Range")
								{
									valid_hit = false;
								}
							}
							if (valid_hit == true)
							{
								// if (i % 2 == 0)
									current_player = Instantiate(childen1, hit[0].point, Quaternion.identity);
								// else
								// 	current_player = Instantiate(childen2, hit[0].point, Quaternion.identity);
								ranges = GameObject.FindGameObjectsWithTag("Range");
								spaces = GameObject.FindGameObjectsWithTag("Space");
								foreach (GameObject range in ranges)
									Destroy(range);
								foreach (GameObject space in spaces)
									Destroy(space);
								player_range_generated = false;
								user_input.GetComponent<user_input>().input_active = true;
							}
						}			
					}
				}
				if (children_chosen == true && player_range_generated == false)
				{
					if (user_input.GetComponent<user_input>().input_chosen == true)
					{
						// GetComponent<add_force>().force(user_input.GetComponent<user_input>().force, user_input.GetComponent<user_input>().x);   //to change
						// GetComponent<add_force>();
						current_player.GetComponent<add_force>().enabled = true;
						if (check_stop() == true)
						{
							children_chosen = false;
							GetComponent<generate_children2>().enabled = true;
							if (i < nbr_children - 1)
							{
								user_input.GetComponent<user_input>().input_chosen = false;
								// user_input.GetComponent<user_input>().input_active = true;
							}
							GetComponent<generate_children>().enabled = false;
						}
						// if (i < nbr_children - 1)
						// {
						// 	user_input.GetComponent<user_input>().input_chosen = false;
						// 	user_input.GetComponent<user_input>().input_active = true;
						// }
						// children_chosen = false;
						i++;
					}
				}
			}
		}
	}

	bool check_stop()
	{
		all_stop = true;

		root = GameObject.FindGameObjectWithTag("Root");
		if (!((Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.x) < 0.01) && Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.y) < 0.01))
		{
			all_stop = false;
		}
		parent1s = GameObject.FindGameObjectsWithTag("Player1");
		parent2s = GameObject.FindGameObjectsWithTag("Player2");

		// player_parents = GameObject.FindGameObjectsWithTag("Player1");
		foreach (GameObject parent in parent1s)
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
		

		// player_parents = GameObject.FindGameObjectsWithTag("Player2");
		foreach (GameObject parent in parent2s)
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

		children1 = GameObject.FindGameObjectsWithTag("Children1");
		children2 = GameObject.FindGameObjectsWithTag("Children2");

		foreach (GameObject child1 in children1)
		{
					if (!((Mathf.Abs(child1.GetComponent<Rigidbody2D>().velocity.x) < 0.01) && Mathf.Abs(child1.GetComponent<Rigidbody2D>().velocity.y) < 0.01))
			{
				all_stop = false;
			}
		}

				foreach (GameObject child2 in children1)
		{
					if (!((Mathf.Abs(child2.GetComponent<Rigidbody2D>().velocity.x) < 0.01) && Mathf.Abs(child2.GetComponent<Rigidbody2D>().velocity.y) < 0.01))
			{
				all_stop = false;
			}
		}






		return all_stop;
	}
}

