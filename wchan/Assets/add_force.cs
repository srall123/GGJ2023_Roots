using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_force : MonoBehaviour
{
	public void force(int force, int x)  //to change
    {
		if (transform.tag == "Player")
		{
			GetComponent<generate_parent>().current_player.transform.position += new Vector3(x, force, 0);  //to change
		}
		if (transform.tag == "Root")
		{
			transform.position += new Vector3(0, force, 0);
		}
		if (transform.tag == "Children")
		{
			GetComponent<generate_children>().current_player.transform.position += new Vector3(0, 2, 0);  //to change
		}
    }
}
