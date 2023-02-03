using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down);
			for (int i = 0; i < hits.Length; ++i)
			{
				Debug.LogFormat("The name of collider {0} is \"{1}\".", 
					i, hits[i].collider.gameObject.name);
			}


		}



        
    }
}
