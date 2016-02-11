using UnityEngine;
using System.Collections;

public class LocalText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UILabel lbl = transform.GetComponent<UILabel>();
		if(lbl != null){
			lbl.text = UtilMgr.GetLocalText(lbl.text);
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
