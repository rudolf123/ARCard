using UnityEngine;
using System.Collections;

public class SearchManager : MonoBehaviour {
	public GameObject serchResultsPanel;
	public GameObject prefabSearchItem;
	// Use this for initialization

	public void findClick(){
		Instantiate(prefabSearchItem, transform.position , Quaternion.identity);
		//GameObject o = prefabSearchItem.transform.Find ("obj_Prefab").gameObject;
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (canavas)
			//canavas.
	}



}
