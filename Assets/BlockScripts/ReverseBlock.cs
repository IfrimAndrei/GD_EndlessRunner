using UnityEngine;
using System.Collections;

public class ReverseBlock : MonoBehaviour {

	void Start ()
	{
		GetComponent<Rigidbody2D>().gravityScale -= Time.timeSinceLevelLoad / 100f;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y > 5.5f || transform.position.y < -10f)
		{
			Destroy(gameObject);
		}
	}

}
