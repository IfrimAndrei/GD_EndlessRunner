using UnityEngine;
using System.Collections;

public class ReverseBlock : MonoBehaviour {

	void Start ()
	{
		int x=Random.Range(2, 8);
		GetComponent<Rigidbody2D>().gravityScale -= Time.timeSinceLevelLoad / (x*10f);
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y > 15f || transform.position.y < -20f)
		{
			Destroy(gameObject);
		}
	}

}
