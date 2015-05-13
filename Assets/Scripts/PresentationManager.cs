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
		string currentPresentation = "";
		int CMITIterator;
		int MILAIterator;
		List<string> runnigpresentations;
		bool isCMITRunnig = false;
		bool isMILARunnig = false;
		// Use this for initialization
		void Start ()
		{
				MILAslides = new List<GameObject> ();
				CMITslides = new List<GameObject> ();
				CMITslides.Add (GameObject.Find ("CMITSlide1"));
				CMITslides.Add (GameObject.Find ("CMITSlide2"));
				CMITslides.Add (GameObject.Find ("CMITSlide3"));
				CMITslides.Add (GameObject.Find ("CMITSlide4"));
				//MILAslides.Add (GameObject.Find ("MilaSlide0"));
				MILAslides.Add (GameObject.Find ("MilaSlide1"));
				MILAslides.Add (GameObject.Find ("MilaSlide2"));
				MILAslides.Add (GameObject.Find ("MilaSlide3"));
				runnigpresentations = new List<string> ();
				currentSlide = null;
				CMITIterator = 0;
				MILAIterator = 0;
				Debug.Log ("SlidesLen: " + CMITslides.Count.ToString ());
				foreach (GameObject go in CMITslides) {
					Debug.Log ("SetActive (false) = " + go.transform.name);			
					go.SetActive (false);
				}

				foreach (GameObject go in MILAslides) {
					Debug.Log ("SetActive (false) = " + go.transform.name);	
					go.SetActive (false);
				}
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

	public void setActiveMila(){
		GameObject mila = MILAImageTarget.transform.Find ("MilaSlide0").gameObject;
		mila.SetActive(true);
	}

		public void runPresentation (string name)
		{
				currentPresentation = name;
				Debug.Log ("Starting presentation: " + name);
		if (name.Equals("CMIT")) {
								GameObject runCanvas = CMITImageTarget.transform.Find ("RunCanvas").gameObject;
								runCanvas.SetActive (false);
								showSlide (CMITIterator);
								isCMITRunnig = true;
						}
				if ("MILA".Equals (name)) {
					GameObject runCanvas = MILAImageTarget.transform.Find ("RunCanvas").gameObject;
					runCanvas.SetActive (false);
					showSlide (MILAIterator);
					isMILARunnig = true;
						}
		}

		public void OnMarkerFound (string markerName)
		{
				Debug.Log ("Marker: " + markerName + " was found");
				if (markerName == "viz2") {
						if (!isCMITRunnig) {
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
				if (markerName == "milaviz") {
					if (!isMILARunnig) {
						GameObject runCanvas = MILAImageTarget.transform.Find ("RunCanvas").gameObject;
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

				if (markerName == "milaviz") {
					if (currentSlide)
						currentSlide.SetActive (false);
					GameObject runCanvas = MILAImageTarget.transform.Find ("RunCanvas").gameObject;
					//Object prefab = new Object ();
					//prefab = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/MessageBox.prefab", typeof(GameObject));
					//runCanvas = Instantiate (Resources.Load ("RunCanvas")) as GameObject;
					//runCanvas.transform.SetParent (ImageTarget.transform);
					runCanvas.SetActive (false);
					runTriggerAnimation (runCanvas.transform.Find ("buRunPresentation").gameObject, "Disappear");
			GameObject mila = MILAImageTarget.transform.Find ("MilaSlide0").gameObject;
			mila.SetActive(false);
				}
		}

		public void nextSlide ()
		{
			if ("CMIT".Equals (currentPresentation)) {
							if (CMITIterator < CMITslides.Count - 1) {
									CMITIterator++;
									showSlide (CMITIterator);
							}
							Debug.Log ("iterator = " + CMITIterator);
			}

			if ("MILA".Equals (currentPresentation)) {
				if (MILAIterator < MILAslides.Count - 1) {
					MILAIterator++;
					showSlide (MILAIterator);
				}
				Debug.Log ("iterator = " + CMITIterator);
			}

		}

		public void prevSlide ()
		{
		if ("CMIT".Equals (currentPresentation)) {
						if (CMITIterator > 0) {
								CMITIterator--;
								showSlide (CMITIterator);
						}
						Debug.Log ("iterator = " + CMITIterator);
				}
		if ("MILA".Equals (currentPresentation)) {
			if (MILAIterator > 0) {
				MILAIterator--;
				showSlide (MILAIterator);
			}
			Debug.Log ("iterator = " + MILAIterator);
		}


		}

		void showSlide (int id)
		{
				if (currentSlide)
						currentSlide.SetActive (false);
				if ("CMIT".Equals (currentPresentation)) {
						currentSlide = CMITslides [id];
						currentSlide.SetActive (true);
						Debug.Log ("current slide id = " + id.ToString ());
				}
				if ("MILA".Equals (currentPresentation)) {
						currentSlide = MILAslides [id];
						currentSlide.SetActive (true);
						Debug.Log ("current slide id = " + id.ToString ());
				}
		}

		IEnumerator DoMoving ()
		{
				//iTween.RotateBy(gameObject, iTween.Hash("z", 1, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .3));
				yield return new WaitForSeconds (2f);
				// ... other sequential actions here?
		}
}
