using UnityEngine;
using System.Collections;

public class Cherry : MonoBehaviour
{

	void Start()
	{
		int x = Random.Range(6, 8);
		GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / (x * 10f);
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
