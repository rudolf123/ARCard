using UnityEngine;
using System.Collections;

public class MenuNavigationScript : MonoBehaviour
{

		public GameObject MainWindowGo;
		public GameObject currentWindow;

		public void onMenuButtonClick (GameObject go)
		{
				MainWindowGo.GetComponent<Animator> ().Play ("SlideOut");
				go.GetComponent<Animator> ().Play ("SlideInMail");
				currentWindow = go;
		}

		public void onBackButtonClick (GameObject go)
		{
				go.GetComponent<Animator> ().Play ("SlideOutMail");
				MainWindowGo.GetComponent<Animator> ().Play ("SlideIn");
				currentWindow = MainWindowGo;
		}

		public void SetActiveScene (int id)
		{
				Application.LoadLevel (id);
		}

		void Start ()
		{
				MainWindowGo.GetComponent<Animator> ().enabled = true;
		}

	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Escape) && currentWindow.name.Equals ("MainWindow"))
						Application.Quit ();

		}
}
