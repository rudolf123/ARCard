using UnityEngine;
using System.Collections;

public enum AnimationType
{
		rotate = 0,
		rotateY = 1,
		move = 2,
		punchscale = 3,

		linerotate = 4,

		movefrom = 5,

		
		none = 6,
	linerotateY = 7,

}

public class iTweenAnimation : MonoBehaviour
{
		bool initialized = false;
		public AnimationType currentAnim = AnimationType.none;

		// Use this for initialization
		void Start ()
		{
				StartAnimation (currentAnim);
		}
	 
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnDisable ()
		{
				initialized = false;
		}

		void Initialize ()
		{
				initialized = true;
			
				StartAnimation (currentAnim);
		}

		void Awake ()
		{
				StartAnimation (currentAnim);
		}

		public void StartAnimation (AnimationType animType)
		{
				switch (animType) {
				case AnimationType.rotate:
						StartRotate ();
						break;
				case AnimationType.rotateY:
						StartRotateY ();
						break;
				case AnimationType.move:
						StartMoveAdd ();
						break;
				case AnimationType.punchscale:
						StartPunchScale (new Vector3 (1, 1, 1));
						break;
				case AnimationType.linerotate:
						StartRotateLine ();
						break;
				case AnimationType.linerotateY:
						StartRotateLineY ();
						break;
				case AnimationType.movefrom:
						StartMoveFrom ();
						break;
				default:
						return;
						break;
				}
		}

		void StartRotate ()
		{
				iTween.RotateBy (gameObject, iTween.Hash ("z", 1, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .3));
		}

		void StartRotateY ()
		{
				iTween.RotateBy (gameObject, iTween.Hash ("y", 1, "easeType", "easeInSine", "loopType", "pingPong", "delay", .3));
		}

		void StartRotateLine ()
		{
				iTween.RotateBy (gameObject, iTween.Hash ("y", 1f, "easeType", "easeOutCirc", "speed", 1f));
		}

		void StartPunchScale (Vector3 vec)
		{
				//Vector3 vec = new Vector3 (1,1,1);
				iTween.PunchScale (gameObject, iTween.Hash ("amount", vec, "time", 2f));
		}

		void StartMoveAdd ()
		{
				iTween.MoveAdd (gameObject, iTween.Hash ("y", 20, "easeType", "easeInSine", "loopType", "pingPong", "delay", .001));
		}

		void StartMoveTo ()
		{
				iTween.MoveTo (gameObject, iTween.Hash ("position", new Vector3 (0, 300, 0), "time", .6, "easetype", "easeincubic"));
		}

		void StartMoveFrom ()
		{
				iTween.MoveAdd (gameObject, iTween.Hash ("z", 80, "easeType", iTween.EaseType.linear, "loopType", "pingPong", "time", 5f, "delay", .001));
		}

		void StartRotateLineY ()
		{
				iTween.RotateBy (gameObject, iTween.Hash ("z", 1f, "easeType", "easeOutCirc", "speed", 1f));
		}
}
