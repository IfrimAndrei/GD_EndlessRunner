using UnityEngine;
using System.Collections;

public class Cherry : MonoBehaviour
{

	void Start()
	{
		int x = Random.Range(4, 8);
		float speed = Time.timeSinceLevelLoad / (x * 20f);
		if (speed > 0.7f)
			speed = 0.7f;
		GetComponent<Rigidbody2D>().gravityScale += speed;
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y > 20f || transform.position.y < -15f)
		{
			Destroy(gameObject);
		}
	}

	/*
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag != "P_White" || col.gameObject.tag != "P_Black")
		{
			Physics2D.IgnoreCollision(col.collider, this.gameObject.GetComponent<Collider2D>(), true);
		}
	}
	*/
}
