using UnityEngine;
using System.Collections;

public class BtnEditList : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.root.FindChild("Lineup").GetComponent<MyLineup>().IsDeletable){
			transform.FindChild("Background").gameObject.SetActive(false);
			transform.FindChild("LblDone").gameObject.SetActive(true);
		} else{
			transform.FindChild("Background").gameObject.SetActive(true);
			transform.FindChild("LblDone").gameObject.SetActive(false);
		}
	}

	public void OnClick(){
		if(transform.root.FindChild("Lineup").GetComponent<MyLineup>().IsDeletable){
			transform.root.FindChild("Lineup").GetComponent<MyLineup>().IsDeletable = false;

		} else{
			transform.root.FindChild("Lineup").GetComponent<MyLineup>().IsDeletable = true;

		}
	}
}
