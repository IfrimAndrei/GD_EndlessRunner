using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

	public float speed = 15f;
	public float mapWidth = 5f;

	public Texture2D cursorTexture;


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
		Debug.Log(col.gameObject.tag);
		int x;
		if (col.gameObject.tag == "Red")
			x = 1;
		else
			FindObjectOfType<GameManager>().EndGame();
	}

}
