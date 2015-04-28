using UnityEngine;
using System.Collections;

public class iTweenAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartRotate(){
		iTween.RotateBy(gameObject, iTween.Hash("z", 1, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .3));
	}

	public void StartPunchScale(Vector3 vec){
		//Vector3 vec = new Vector3 (1,1,1);
		iTween.PunchScale (gameObject, iTween.Hash("amount", vec, "time", 2f));
	}

	public void StartMoveAdd(){
		iTween.MoveAdd (gameObject, iTween.Hash("y", 20, "easeType", "easeInSine", "loopType", "pingPong", "delay", .001));
	}

	public void StartMoveFrom(){
		iTween.MoveTo (gameObject,iTween.Hash("position",new Vector3(0,30,0) ,  "time" ,.6, "easetype" ,"easeincubic"));
	}
}
