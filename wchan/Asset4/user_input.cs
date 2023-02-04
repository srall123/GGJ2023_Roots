using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class user_input : MonoBehaviour
{
	public bool input_chosen;
	public bool input_active;
	public int force;
	public int x;  //to delete
	 
    // Start is called before the first frame update
    void Start()
    {
		input_chosen = false;
		input_active = true;
		force = 0;

    }

    // Update is called once per frame
    void Update()
    {
		if (input_active == true)
		{
			if (Input.GetKeyDown("space"))
			{
				Debug.Log("Here4");
				Debug.Log("KeyDown");
				input_chosen = true;
				Debug.Log(input_chosen);
				force = 20;
				x = 20; //to delete
				input_active = false;
			}
		}
    }
}
