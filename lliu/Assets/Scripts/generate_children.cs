using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_children : MonoBehaviour
{
	public GameObject range;
	public GameObject space;
	public GameObject child;
	public GameObject child2;
	private int i;
	public GameObject Player;
	GameObject[] player_parents;
	GameObject[] ranges;
	GameObject[] spaces;
	bool player_range_generated;
	bool children_chosen;
	GameObject current_player;
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
		if (Player.GetComponent<player>().start_shot == true)
		{
			if (i < 4)
			{
				if (player_range_generated == false && children_chosen == false)
				{
					if (i % 2 != 0)
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
					Player.GetComponent<player>().start_shot = false;
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
								Debug.Log("test");
								if (i % 2 != 0)
									current_player = Instantiate(child, hit[0].point, Quaternion.identity);
								else
									current_player = Instantiate(child2, hit[0].point, Quaternion.identity);
								Player.GetComponent<player>().start_shot = false;
								ranges = GameObject.FindGameObjectsWithTag("Range");
								spaces = GameObject.FindGameObjectsWithTag("Space");
								foreach (GameObject range in ranges)
									Destroy(range);
								foreach (GameObject space in spaces)
									Destroy(space);
								player_range_generated = false;
							}
						}
					}
				}
				if (children_chosen == true && player_range_generated == false)
				{
					if (Mathf.Abs(current_player.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(current_player.GetComponent<Rigidbody2D>().velocity.y) < 0.01)
						Player.GetComponent<player>().start_shot = true;
					children_chosen = false;
					i++;
				}
				Debug.Log(i);
				Debug.Log(Player.GetComponent<player>().start_shot);
			}
			if ( i == 4 && Player.GetComponent<player>().start_shot == true)
				Player.GetComponent<player>().end_game = true;
		}
	}
}

