using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
	
	public GameObject platform;
	public Vector2 direction;
	public float x_position;
	public float y_position;
	public Vector2 pointA;
	public Vector2 pointB;
	public float offset;
	public float platformSpeed;
	public int delay;
	// Use this for initialization
	IEnumerator Start () {
	 pointA = new Vector2(platform.transform.position.x,platform.transform.position.y + offset + offset);
	 pointB = new Vector2(platform.transform.position.x,platform.transform.position.y - offset - offset);
	 while(true)
	 {
		 yield return new WaitForSeconds(delay);
		 yield return StartCoroutine(MovePlatform(platform.transform,pointA,pointB,platformSpeed));
		 yield return StartCoroutine(MovePlatform(platform.transform,pointB,pointA,platformSpeed));
	 }
	 
	}
	
	// Update is called once per frame
	void Update () {
		x_position = platform.transform.position.x;
		y_position = platform.transform.position.y;
	}
	
	IEnumerator MovePlatform(Transform thisTransform, Vector2 startPos, Vector2 endPos, float time)
	{
		var i=0.0f;
		var rate=1.0f/time;
		while(i<1.0f)
		{
			i += Time.deltaTime * rate;
			thisTransform.position = Vector2.Lerp(endPos,startPos, i);
			yield return null;
		}
	}
}
