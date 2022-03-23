using UnityEngine;
using System.Collections;

public class Golden : MonoBehaviour {

	void Start ()
	{
		int x = Random.Range(6, 8);
		GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad * (x*10f);
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y > 20f || transform.position.y < -15f)
		{
			Destroy(gameObject);
		}
	}

}
