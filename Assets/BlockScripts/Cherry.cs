using UnityEngine;
using System.Collections;

public class Cherry : MonoBehaviour {

	void Start ()
	{
		GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 60f;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y > 10f || transform.position.y < -5.5f)
		{
			Destroy(gameObject);
		}
	}

}
