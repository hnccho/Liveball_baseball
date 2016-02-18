using UnityEngine;
using System.Collections;

public class LocalText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UILabel lbl = transform.GetComponent<UILabel>();
		if(lbl != null){
			string value = UtilMgr.GetLocalText(lbl.name);
			if(value.Equals(lbl.name)){
				GameObject obj = gameObject;
				string path = "/" + obj.name;
				while(obj.transform.parent != null){
					obj = obj.transform.parent.gameObject;
					path = "/" + obj.name + path;
				}
				Debug.Log("My path is "+path);
			}
			lbl.text = value;
			return;
		}
//		StartCoroutine(ttt());
	}

//	IEnumerator ttt(){
//		do{
//			yield return new WaitForSeconds(1);
//			Debug.Log("Title text is : "+Localization.Get("Title"));
//		} while(Localization.Get("Title").Equals("Title"));
//
//		UILabel lbl = transform.GetComponent<UILabel>();
//		if(lbl != null){
//			lbl.text = UtilMgr.GetLocalText(lbl.text);
//		}
//
//		yield return null;
//	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
