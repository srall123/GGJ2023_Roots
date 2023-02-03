using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class root : MonoBehaviour
{
	public bool root_shoot;
	public GameObject user_input;

    // Start is called before the first frame update
    void Start()
    {
		root_shoot = false; 
    }

    // Update is called once per frame
    void Update()
    {
		if (root_shoot == false)
		{
			if (user_input.GetComponent<user_input>().input_chosen == true)
			{
				GetComponent<add_force>().force(user_input.GetComponent<user_input>().force, user_input.GetComponent<user_input>().x); //to change
				user_input.GetComponent<user_input>().input_chosen = false;
				root_shoot = true;
				user_input.GetComponent<user_input>().input_active = true;
			}
		}        
    }
}
