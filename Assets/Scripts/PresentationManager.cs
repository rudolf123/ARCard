using UnityEngine;
using System.Collections;

public class PresentationManager : MonoBehaviour {
	GameObject[] models;
	GameObject currentModel = null;
	int iterator;
	// Use this for initialization
	void Start () {
		models = GameObject.FindGameObjectsWithTag("presentationModels");
		currentModel = null;
		iterator = 0;
		Debug.Log ("ModelsLen");
		Debug.Log (models.Length);
		for (int i=0; i < models.Length; i++)
			models[i].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void slideForward(){
		if (iterator < models.Length - 1) {
			iterator++;
			showModelWithId (iterator);
		}
		Debug.Log ("iterator = " + iterator);
	}

	public void slideBackward(){
		if (iterator > 0) {
			iterator--;
			showModelWithId (iterator);
		}
		Debug.Log ("iterator = " + iterator);
	}

	void showModelWithId(int id){
		if (currentModel)
				currentModel.SetActive(false);
		currentModel = models [id];
		currentModel.SetActive(true);
		Debug.Log ("id = " + id);
	}
}
