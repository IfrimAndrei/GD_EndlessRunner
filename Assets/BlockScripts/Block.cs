using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    void Start()
    {

        int x = Random.Range(2, 8);
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / (x * 10f);
        int y = Random.Range(0, 2);
        if (y == 1)
        {
            this.tag = "White";
            var thisRender = this.GetComponent<SpriteRenderer>();
            thisRender.color = new Color(255, 255, 255, 1);
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
    {	string tag = col.gameObject.tag;
		if(tag != "Score" && tag!="Slow" && tag!="ResetBoost")
        {
            if (tag== "White")
            {
                //var thisRender = this.GetComponent<SpriteRenderer>();
                //thisRender.color = new Color(0, 0, 0, 1);
                //this.tag = "Black";

                var thisRender = col.gameObject.GetComponent<SpriteRenderer>();
                thisRender.color = new Color(0, 0, 0, 1);
                col.rigidbody.gravityScale *= -1;
                col.gameObject.tag = "Black";
            }
            else if (tag == "Black")
            {
                //var thisRender = this.GetComponent<SpriteRenderer>();
                //thisRender.color = new Color(255, 255, 255, 1);
                //this.tag = "White";

                var thisRender = col.gameObject.GetComponent<SpriteRenderer>();
                thisRender.color = new Color(255, 255, 255, 1);
                col.rigidbody.gravityScale *= -1;
                col.gameObject.tag = "White";
            }
        }
    }
}
