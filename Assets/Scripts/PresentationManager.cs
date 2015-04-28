using UnityEngine;
using System.Collections;

public class PresentationManager : MonoBehaviour
{
		public GameObject ImageTarget;
		GameObject[] models;
		GameObject currentModel = null;
		int iterator;
		// Use this for initialization
		void Start ()
		{
				models = GameObject.FindGameObjectsWithTag ("presentationModels");
				currentModel = null;
				iterator = 0;
				Debug.Log ("ModelsLen");
				Debug.Log (models.Length);
				for (int i=0; i < models.Length; i++)
						models [i].SetActive (false);
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
		GameObject runCanvas = ImageTarget.transform.Find("RunCanvas").gameObject;
		runTriggerAnimation (runCanvas.transform.Find("buRunPresentation").gameObject, "Disappear");
		runCanvas.SetActive (false);
		GameObject bulb = ImageTarget.transform.Find("Slide_1").transform.Find("Bulb").gameObject;
		GameObject SlideText1 = ImageTarget.transform.Find("Slide_1").transform.Find("TextSlide1").gameObject;
		SlideText1.SetActive (true);
		bulb.SetActive (true);
		bulb.GetComponent<iTweenAnimation> ().StartPunchScale (new Vector3 (1,1,1));
		bulb.GetComponent<iTweenAnimation> ().StartRotate ();
		SlideText1.GetComponent<iTweenAnimation> ().StartPunchScale (new Vector3 (0.01f,0.01f,0.01f));
		SlideText1.GetComponent<iTweenAnimation> ().StartMoveAdd ();
		//runCanvas.SetActive (false);
		}

		public void OnMarkerFound (string markerName)
		{
		Debug.Log ("Marker: " + markerName + " was found");
				if (markerName == "viz2") {
						GameObject runCanvas = ImageTarget.transform.Find("RunCanvas").gameObject;
						//Object prefab = new Object ();
						//prefab = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/MessageBox.prefab", typeof(GameObject));
						//runCanvas = Instantiate (Resources.Load ("RunCanvas")) as GameObject;
						//runCanvas.transform.SetParent (ImageTarget.transform);
						runCanvas.SetActive (true);
						runTriggerAnimation (runCanvas.transform.Find("buRunPresentation").gameObject, "Appear");
				}
		}

		public void OnMarkerLost (string markerName)
		{
		Debug.Log ("Marker: " + markerName + " was lost");
		if (markerName == "viz2") {
			GameObject runCanvas = ImageTarget.transform.Find("RunCanvas").gameObject;
			//Object prefab = new Object ();
			//prefab = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/MessageBox.prefab", typeof(GameObject));
			//runCanvas = Instantiate (Resources.Load ("RunCanvas")) as GameObject;
			//runCanvas.transform.SetParent (ImageTarget.transform);
			runCanvas.SetActive (false);
			runTriggerAnimation (runCanvas.transform.Find("buRunPresentation").gameObject, "Disappear");
		}
		}

		public void slideForward ()
		{
				if (iterator < models.Length - 1) {
						iterator++;
						showModelWithId (iterator);
				}
				Debug.Log ("iterator = " + iterator);
		}

		public void slideBackward ()
		{
				if (iterator > 0) {
						iterator--;
						showModelWithId (iterator);
				}
				Debug.Log ("iterator = " + iterator);
		}

		void showModelWithId (int id)
		{
				if (currentModel)
						currentModel.SetActive (false);
				currentModel = models [id];
				currentModel.SetActive (true);
				Debug.Log ("id = " + id);
		}

		IEnumerator DoMoving()
		{
			//iTween.RotateBy(gameObject, iTween.Hash("z", 1, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .3));
			yield return new WaitForSeconds(2f);
			// ... other sequential actions here?
		}
}
