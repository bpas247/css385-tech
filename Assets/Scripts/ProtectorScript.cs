using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectorScript : MonoBehaviour
{
	public float speed;
	private Vector3 target; // Where the protector is currently going

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

		if (Input.GetMouseButton(0))
		{

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.name == "Floor")
				{
					target = new Vector3(hit.point.x, 0, hit.point.z);
				}
			}
		}
	}
}
