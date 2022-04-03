using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static float slowness = 10f;
	public static int cherry = 3;
	float sloweDeltaT;
	float normalDeltaT;
	public GameObject player;
	public void EndGame ()
	{
		StartCoroutine(RestartLevel());
		Cursor.visible = true;
	}
    public void Start()
    {
		sloweDeltaT= Time.fixedDeltaTime / slowness;
		normalDeltaT = Time.fixedDeltaTime;
	}

    private void Update()
	{
		if(cherry>0)
			if (Input.GetMouseButtonDown(0))
			{
				StartCoroutine(SlowMotion(true));
				cherry--;
			}
		if (Input.GetMouseButtonUp(0))
		{
			StartCoroutine(SlowMotion(false));
		}
		
		if (Input.GetMouseButtonDown(1))
		{
			if (player.tag == "P_White")
			{
				var playerRender = player.GetComponent<Renderer>();
				playerRender.material.SetColor("_Color", Color.black);
				player.tag = "P_Black";
			}
			else if (player.tag == "P_Black")
			{
				var playerRender = player.GetComponent<Renderer>();
				playerRender.material.SetColor("_Color", Color.white);
				player.tag = "P_White";
			}
		}
	}
	IEnumerator RestartLevel ()
	{
		Time.timeScale = 1f / slowness;
		Time.fixedDeltaTime = sloweDeltaT;

		yield return new WaitForSeconds(1f / slowness);
		BlockSpawner.waveCounter = 0;
		cherry = 3;
		Time.timeScale = 1f;
		Time.fixedDeltaTime = normalDeltaT;

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		UI.resetScore();
	}
	IEnumerator SlowMotion(bool slowOn)
    {
		if (slowOn)
		{
			Time.timeScale = 1f / slowness;
			Time.fixedDeltaTime = sloweDeltaT;

			yield return new WaitForSeconds(1f / slowness);
			Time.timeScale = 1f;
			Time.fixedDeltaTime = normalDeltaT;

		}
        else
        {
			Time.timeScale = 1f;
			Time.fixedDeltaTime = normalDeltaT;
		}
	}

}
