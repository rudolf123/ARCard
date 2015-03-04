using UnityEngine;
using System.Collections;

public class delay : MonoBehaviour {
	public GameObject gobj;

	IEnumerator MyMethod() {
		Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(2);
		Debug.Log("After Waiting 2 Seconds");
	}
	// Use this for initialization
	void Start () {
		Debug.Log("started");
		gobj.animation.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
