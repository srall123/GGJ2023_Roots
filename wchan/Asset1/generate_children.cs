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


    // Start is called before the first frame update
    void Start()
    {
		player_range_generated = false;
		children_chosen = false;
		i = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if (start_point.GetComponent<generate_parent>().all_parent_generated == true)
		{
			if (i < nbr_children)
			{
				if (player_range_generated == false && children_chosen == false)
				{
					if (i % 2 == 0)
						player_parents = GameObject.FindGameObjectsWithTag("Player1");
					else
						player_parents = GameObject.FindGameObjectsWithTag("Player2");
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
					if (Input.GetMouseButtonDown(0))
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
								if (i % 2 == 0)
									current_player = Instantiate(childen1, hit[0].point, Quaternion.identity);
								else
									current_player = Instantiate(childen2, hit[0].point, Quaternion.identity);
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
						GetComponent<add_force>();
						if (i < nbr_children - 1)
						{
							user_input.GetComponent<user_input>().input_chosen = false;
							user_input.GetComponent<user_input>().input_active = true;
						}
						children_chosen = false;
						i++;
					}
				}
			}
		}
	}
}

