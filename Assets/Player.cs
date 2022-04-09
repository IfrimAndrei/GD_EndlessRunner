using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

	// public float speed = 15f;
	public float mapWidth = 5f;
	public Texture2D cursorTexture;
	// public float speed = 0.5f;

	void Start ()
	{
		//Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);//fix sa mearga mai smooth, poate fi scos
		Cursor.visible = false;
	}


    void FixedUpdate ()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
		transform.position = mousePosition;
	}

	void OnCollisionEnter2D (Collision2D col)
	{	
		if (col.gameObject.tag == "Red")
		{
			GameManager.cherry++;
			Destroy(col.gameObject);
		}
		else if (col.gameObject.tag == "White" && this.tag== "P_White")
		{
			//Physics2D.IgnoreCollision(col.collider, this.gameObject.GetComponent<Collider2D>());
			col.rigidbody.gravityScale *= -1;

			var thisRender = col.gameObject.GetComponent<SpriteRenderer>();
			thisRender.color = new Color(0, 0, 0, 1);
			col.gameObject.tag = "Black";
		}
		else if (col.gameObject.tag == "Black" && this.tag == "P_Black"){
			col.rigidbody.gravityScale *= -1;

			var thisRender = col.gameObject.GetComponent<SpriteRenderer>();
			thisRender.color = new Color(255, 255, 255, 1);
			col.gameObject.tag = "White";
		}
		else if(col.gameObject.tag == "Score") {
			Destroy(col.gameObject);
			UI.updateScore();
		}
		else if(col.gameObject.tag == "Slow") {
			Destroy(col.gameObject);

		}
		else if(col.gameObject.tag == "ResetBoost") {
			Destroy(col.gameObject);
			if (GameManager.cherry <= 3)
				GameManager.cherry = 0;
			else
				GameManager.cherry -= 3;
		}
		else
		{
			   Debug.Log(col.gameObject.tag);
			   FindObjectOfType<GameManager>().EndGame();
		}
			
	}

}
