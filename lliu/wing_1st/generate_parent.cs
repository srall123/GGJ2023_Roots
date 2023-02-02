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

    // Start is called before the first frame update
    void Start()
    {
		i = 0;
		parent_generated = false;
		all_parent_generated = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (i < nbr_parent && root.GetComponent<root>().root_shoot == true)
		{
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
				if (user_input.GetComponent<user_input>().input_chosen == true)
				{
					GetComponent<add_force>().force(user_input.GetComponent<user_input>().force, user_input.GetComponent<user_input>().x);   //to change
					if (i < nbr_parent - 1)
					{
						user_input.GetComponent<user_input>().input_chosen = false;
						user_input.GetComponent<user_input>().input_active = true;
					}
					parent_generated = false;
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
}
