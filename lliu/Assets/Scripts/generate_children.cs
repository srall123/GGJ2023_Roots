using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_children : MonoBehaviour
{
	public GameObject range;
	public GameObject space;
	public GameObject childen1;
	public GameObject childen2;
	int i;
	public GameObject player;
	public GameObject[] player_parents;
	public GameObject[] ranges;
	public GameObject[] spaces;
	GameObject[] player1;
	GameObject[] player2;
	GameObject[] children1;
	GameObject[] children2;
	bool player_range_generated;
	bool children_chosen;
	public GameObject current_player;
	bool valid_hit;
	bool all_stop;

    void Start()
    {
		player_range_generated = false;
		i = 0;
		all_stop = true;
    }

    void Update()
    {
		if (player.GetComponent<player>().all_parent_generated == true)
		{
			if (i < 4)
			{
				if (player_range_generated == false)
				{
					if (i % 2 == 1)
						player_parents = GameObject.FindGameObjectsWithTag("Player1");
					else
						player_parents = GameObject.FindGameObjectsWithTag("Player2");
					check_stop();
					if (all_stop)
					{
						foreach (GameObject parent in player_parents)
						{
							Instantiate(range, parent.transform.position, Quaternion.identity);
							Instantiate(space, parent.transform.position, Quaternion.identity);
						}
						player_range_generated = true;
					}
					else
						all_stop = true;
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
								if (i % 2 == 1)
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
								i++;
								Debug.Log(i);
							}
						}
					}
				}
			}
			else if ( i == 4)
			{
				check_stop();
				if (all_stop)
					player.GetComponent<player>().end_game = true;
				else
					all_stop = true;
			}
		}
	}

    void check_stop()
	{
        player1 = GameObject.FindGameObjectsWithTag("Player1");
		player2 = GameObject.FindGameObjectsWithTag("Player2");
        children1 = GameObject.FindGameObjectsWithTag("Children1");
		children2 = GameObject.FindGameObjectsWithTag("Children2");

		foreach (GameObject ball1 in player1)
		{
			if (ball1.GetComponent<Rigidbody2D>().velocity.magnitude > 0.01f)
				all_stop = false;
		}
		foreach (GameObject balls2 in children1)
		{
			if (balls2.GetComponent<Rigidbody2D>().velocity.magnitude > 0.01f)
				all_stop = false;
		}

		foreach (GameObject child1 in player2)
		{
			if (child1.GetComponent<Rigidbody2D>().velocity.magnitude > 0.01f)
				all_stop = false;
		}
		foreach (GameObject child2 in children2)
		{
			if (child2.GetComponent<Rigidbody2D>().velocity.magnitude > 0.01f)
				all_stop = false;
		}
	}

}

