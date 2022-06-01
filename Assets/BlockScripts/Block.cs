using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
	private Color grayColor = new Color(0.31f, 0.31f, 0.31f, 1);

    void Start()
    {

        int x = Random.Range(4, 8);
        float speed = Time.timeSinceLevelLoad / (x * 20f);
        if (speed > 1f)
            speed = 1f;
        GetComponent<Rigidbody2D>().gravityScale += speed;
        int y = Random.Range(0, 5);
        if (y % 2 == 1 && y <= 3)
        {
            this.tag = "White";
            var thisRender = this.GetComponent<SpriteRenderer>();
            thisRender.color = new Color(1, 1, 1, 1);
        }
        else if (y == 4)
        {
            this.tag = "Gray";
            var thisRender = this.GetComponent<SpriteRenderer>();
            thisRender.color = grayColor;
        }
        else
        {
            this.tag = "Black";
            var thisRender = this.GetComponent<SpriteRenderer>();
            thisRender.color = new Color(0, 0, 0, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 20f || transform.position.y < -15f)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;
        if (this.tag == "Gray" && ((col.gameObject.tag == "White") || (col.gameObject.tag == "Black")))
        {
            var thisRender = col.gameObject.GetComponent<SpriteRenderer>();
            thisRender.color = grayColor;

            col.rigidbody.gravityScale *= -0.5f;
            col.gameObject.tag = "Gray";
        }
        if (this.tag!= "Gray" && tag != "Score" && tag != "Slow" && tag != "ResetBoost")
        {
            if (tag == "White")
            {
                //var thisRender = this.GetComponent<SpriteRenderer>();
                //thisRender.color = new Color(0, 0, 0, 1);
                //this.tag = "Black";

                var thisRender = col.gameObject.GetComponent<SpriteRenderer>();
                thisRender.color = new Color(0, 0, 0, 1);
                col.rigidbody.gravityScale *= -0.5f;
                col.gameObject.tag = "Black";
            }
            else if (tag == "Black")
            {
                //var thisRender = this.GetComponent<SpriteRenderer>();
                //thisRender.color = new Color(255, 255, 255, 1);
                //this.tag = "White";

                var thisRender = col.gameObject.GetComponent<SpriteRenderer>();
                thisRender.color = new Color(255, 255, 255, 1);
                col.rigidbody.gravityScale *= -0.5f;
                col.gameObject.tag = "White";
            }
        }
    }
}
