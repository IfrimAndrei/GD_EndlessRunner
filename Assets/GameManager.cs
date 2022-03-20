using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static float slowness = 10f;
	public void EndGame ()
	{
		StartCoroutine(RestartLevel());
		Cursor.visible = true;
	}
    public void Start()
    {
        float sloweDeltaT= Time.fixedDeltaTime / slowness;
		float normalDeltaT = Time.fixedDeltaTime;
	}
    private void Update()
	{    //Sunt prea bun ca si programator
		if (Input.GetMouseButtonDown(0))
		{
			StartCoroutine(SlowMotion(true));
		}
        if (Input.GetMouseButtonUp(0))
        {
			StartCoroutine(SlowMotion(false));
		}

	}
	IEnumerator RestartLevel ()
	{
		Time.timeScale = 1f / slowness;
		Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

		yield return new WaitForSeconds(1f / slowness);

		Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	IEnumerator SlowMotion(bool slowOn)
    {
		if (slowOn)
		{
			Time.timeScale = 1f / slowness;
			Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

			yield return new WaitForSeconds(1f / slowness);

		}
        else
        {
			Time.timeScale = 1f;
			Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
		}
	}

}
