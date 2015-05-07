using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PresentationManager : MonoBehaviour
{
		public GameObject CMITImageTarget;
		public GameObject MILAImageTarget;
	List<GameObject> CMITslides;
	List<GameObject> MILAslides;
		GameObject currentSlide = null;
		int iterator;
		List<string> runnigpresentations;
		bool isRunning = false;
		// Use this for initialization
		void Start ()
		{
				//slides = new List<GameObject> (GameObject.FindGameObjectsWithTag ("Slides"));
		CMITslides = new List<GameObject> ();
		CMITslides.Add (GameObject.Find ("CMITSlide1"));
		CMITslides.Add (GameObject.Find ("CMITSlide2"));
		CMITslides.Add (GameObject.Find ("CMITSlide3"));
		CMITslides.Add (GameObject.Find ("CMITSlide4"));
		MILAslides.Add (GameObject.Find ("MilaSlide1"));
		MILAslides.Add (GameObject.Find ("MilaSlide2"));
		MILAslides.Add (GameObject.Find ("MilaSlide3"));
				runnigpresentations = new List<string> ();
				currentSlide = null;
				iterator = 0;
		Debug.Log ("SlidesLen: " + CMITslides.Count.ToString ());
		foreach (GameObject go in CMITslides)
						go.SetActive (false);

		foreach (GameObject go in MILAslides)
			go.SetActive (false);
		}
	
		// Update is called once per frame
		void Update ()
		{

		}

		public void runTriggerAnimation (GameObject go, string anim, bool isDisableAafterAnim =  false)
		{
				go.GetComponent<Animator> ().SetTrigger (anim);
				if (isDisableAafterAnim) {
						if (!go.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName (anim)) {
								go.SetActive (false);
						}
				}

		}

		public void runPresentation (string name)
		{
				Debug.Log ("Starting presentation: " + name);
				GameObject runCanvas = CMITImageTarget.transform.Find ("RunCanvas").gameObject;
				runCanvas.SetActive (false);
				//runCanvas.GetComponent<iTweenAnimation> ().StartAnimation (AnimationType.rotate);
				showSlide (iterator);
				isRunning = true;
				/*runTriggerAnimation (runCanvas.transform.Find ("buRunPresentation").gameObject, "Disappear");
				runCanvas.SetActive (false);
				GameObject bulb = ImageTarget.transform.Find ("Slide_1").transform.Find ("Bulb").gameObject;
				GameObject SlideText1 = ImageTarget.transform.Find ("Slide_1").transform.Find ("TextSlide1").gameObject;
				SlideText1.SetActive (true);
				bulb.SetActive (true);
				bulb.GetComponent<iTweenAnimation> ().StartPunchScale (new Vector3 (1, 1, 1));
				bulb.GetComponent<iTweenAnimation> ().StartRotate ();
				SlideText1.GetComponent<iTweenAnimation> ().StartPunchScale (new Vector3 (1, 1, 1));
				SlideText1.GetComponent<iTweenAnimation> ().StartMoveAdd ();*/
				//runCanvas.SetActive (false);
		}

		public void OnMarkerFound (string markerName)
		{
				Debug.Log ("Marker: " + markerName + " was found");
				if (markerName == "viz2") {
						if (!isRunning) {
				GameObject runCanvas = CMITImageTarget.transform.Find ("RunCanvas").gameObject;
								//Object prefab = new Object ();
								//prefab = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/MessageBox.prefab", typeof(GameObject));
								//runCanvas = Instantiate (Resources.Load ("RunCanvas")) as GameObject;
								//runCanvas.transform.SetParent (ImageTarget.transform);
								runCanvas.SetActive (true);
								runTriggerAnimation (runCanvas.transform.Find ("buRunPresentation").gameObject, "Appear");

								return;
						}

						if (currentSlide)
								currentSlide.SetActive (true);

				}
		}

		public void OnMarkerLost (string markerName)
		{
				Debug.Log ("Marker: " + markerName + " was lost");
				if (markerName == "viz2") {
						if (currentSlide)
								currentSlide.SetActive (false);

			GameObject runCanvas = CMITImageTarget.transform.Find ("RunCanvas").gameObject;
						//Object prefab = new Object ();
						//prefab = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/MessageBox.prefab", typeof(GameObject));
						//runCanvas = Instantiate (Resources.Load ("RunCanvas")) as GameObject;
						//runCanvas.transform.SetParent (ImageTarget.transform);
						runCanvas.SetActive (false);
						runTriggerAnimation (runCanvas.transform.Find ("buRunPresentation").gameObject, "Disappear");
				}
		}

		public void nextSlide ()
		{
				if (iterator < slides.Count - 1) {
						iterator++;
						showSlide (iterator);
				}
				Debug.Log ("iterator = " + iterator);
		}

		public void prevSlide ()
		{
				if (iterator > 0) {
						iterator--;
						showSlide (iterator);
				}
				Debug.Log ("iterator = " + iterator);
		}

		void showSlide (int id)
		{
				if (currentSlide)
						currentSlide.SetActive (false);
				currentSlide = slides [id];
				currentSlide.SetActive (true);
				Debug.Log ("current slide id = " + id.ToString ());
		}

		IEnumerator DoMoving ()
		{
				//iTween.RotateBy(gameObject, iTween.Hash("z", 1, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .3));
				yield return new WaitForSeconds (2f);
				// ... other sequential actions here?
		}
}
