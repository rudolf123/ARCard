using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UIImage = UnityEngine.UI.Image;

public class MenuNavigationScript : MonoBehaviour
{	
		FirmInfo testinfo;
		List<GameObject> windows_vec;
		GameObject[] windows;
		public GameObject MainWindowGo;
		public GameObject currentWindow;
		public GameObject prefabSearchItem;
		public GameObject SearchResultPanel;
		public GameObject SearchResultInfo;
		GameObject prevWindow;
		List<GameObject> findItems;

		void Awake ()
		{
				
		}

		private IEnumerator WaitForAnimation (Animation animation)
		{
				do {
						yield return null;
				} while ( animation.isPlaying );
		}

		public void showResultInfo (FirmInfo info)
		{
				SearchResultInfo.transform.FindChild ("CompanyName").GetComponent<Text> ().text = info.Name;
				SearchResultInfo.transform.FindChild ("CompanyInfo").GetComponent<Text> ().text = info.Info;
				SearchResultInfo.transform.Find ("CompanyLogo").GetComponent<UIImage> ().sprite = Resources.Load <Sprite>(info.Logo);
				this.switchWindow (SearchResultInfo);
		}

		public void switchWindow (GameObject go)
		{
				Debug.Log ("Switchin to window    " + go.transform.name);
				if (!windows_vec.Contains (currentWindow))
						windows_vec.Add (currentWindow);
				Debug.Log ("Adding window    " + currentWindow.transform.name);
				go.SetActive (true);
				currentWindow.GetComponent<Animator> ().SetTrigger ("FadeOut");
				currentWindow.SetActive (false);
				go.GetComponent<Animator> ().SetTrigger ("FadeIn");
				currentWindow = go;
		}

		public void onBackButtonClick (GameObject go)
		{
				if (go.name.Equals ("ARWindow")) {
						SetActiveScene (0);
						return;
				}
				windows_vec.Remove (currentWindow);
				Debug.Log ("Removing window    " + currentWindow.transform.name);
				currentWindow.GetComponent<Animator> ().SetTrigger ("FadeOut");
				currentWindow.SetActive (false);
				currentWindow = windows_vec [windows_vec.Count - 1];
				currentWindow.SetActive (true);
				currentWindow.GetComponent<Animator> ().SetTrigger ("FadeIn");
				Debug.Log ("Switchin to window    " + currentWindow.transform.name);
				//switchWindow (windows_vec [windows_vec.Count-1]);
		}

		public void SetActiveScene (int id)
		{
				Application.LoadLevel (id);
		}

		void Start ()
		{
				windows_vec = new List<GameObject> ();
				findItems = new List<GameObject> ();
				windows = GameObject.FindGameObjectsWithTag ("window");
				for (int i=0; i < windows.Length; i++)
						windows [i].SetActive (false);

				currentWindow.GetComponent<Animator> ().SetTrigger ("FadeIn");
				windows_vec.Add (currentWindow);

				testinfo = new FirmInfo ();
		}

	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Escape) && currentWindow.name.Equals ("ARWindow")) {
						SetActiveScene (0);
						return;		
				}
				if (Input.GetKeyDown (KeyCode.Escape) && currentWindow.name.Equals ("MainWindow")) {
						Application.Quit ();
						return;
				}
				if (Input.GetKeyDown (KeyCode.Escape) && currentWindow.tag.Equals ("window")) {
						onBackButtonClick (windows_vec [windows_vec.Count]);
				}



		}

		void fillSearchResultItem (FirmInfo info)
		{
				GameObject q = Instantiate (prefabSearchItem) as GameObject;
				q.transform.SetParent (SearchResultPanel.transform, false);
				q.transform.Find ("CompanyName").GetComponent<Text> ().text = info.Name;
				q.transform.Find ("CompanyInfo").GetComponent<Text> ().text = info.Info;
				q.transform.Find ("CompanyLogo").GetComponent<UIImage> ().sprite = Resources.Load <Sprite>(info.Logo);
		//q.transform.Find ("CompanyLogo").GetComponent<Text> ().text = info.Logo;
				UnityEngine.Events.UnityAction action1 = () => {
						this.showResultInfo (info); };
				q.GetComponent<Button> ().onClick.AddListener (action1);

				findItems.Add (q);
		}

		void clearPrevSearchResults ()
		{
				if (findItems.Count != 0)
						foreach (GameObject go in findItems) {
								Destroy (go);
						}
				findItems.Clear ();
		}

		public void StartSearch (GameObject input)
		{
				clearPrevSearchResults ();
				//currentWindow.transform.Find ("NoResults").GetComponent<Animator> ().SetTrigger ("FadeOut");
				string text = input.GetComponent<Text> ().text;
				Debug.Log (input.GetComponent<Text> ().text);

				FirmInfo info;
				info = new FirmInfo ();
				if (text == "Действуй") {
						info.GenerateTemplateCMIT ();
						fillSearchResultItem (info);
						return;		
				}
				if (text == "Юдина") {
						info.GenerateTemplateUdina ();
						fillSearchResultItem (info);	
						return;
				}
				//currentWindow.transform.Find ("NoResults").GetComponent<Animator> ().SetTrigger ("FadeIn");

		}

		void FadeOutMessageBox (GameObject messageBox)
		{
				Debug.Log ("MessageBoxClicked");
				messageBox.GetComponent<Animator> ().SetTrigger ("FadeOut");
				messageBox.SetActive (false);
		}

		void ShowMessageBox (string message)
		{
				GameObject messageBox;
				//Object prefab = new Object ();
				//prefab = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/MessageBox.prefab", typeof(GameObject));
				messageBox = Instantiate (Resources.Load("MessageBox")) as GameObject;
				messageBox.transform.SetParent (currentWindow.transform, false);
				messageBox.GetComponent<Animator> ().SetTrigger ("FadeIn");
				UnityEngine.Events.UnityAction action1 = () => {
						this.FadeOutMessageBox (messageBox); };
				messageBox.GetComponent<Button> ().onClick.AddListener (action1);
				messageBox.transform.Find ("Message").GetComponent<Text> ().text = message;
		}

		public void SendMessage_ ()
		{
				ShowMessageBox ("Письмо отправлено!");

		}
}
