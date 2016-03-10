using UnityEngine;
using System.Collections;

public class TopMenuBtns : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){

		if(name.Equals("BtnMyCards")){
//			transform.root.FindChild("Lobby").gameObject.SetActive(false);
//			transform.root.FindChild("MyCards").gameObject.SetActive(true);
//			transform.root.FindChild("MyCards").localPosition = new Vector3(0, 0);
			UtilMgr.AddBackState(UtilMgr.STATE.MyCard);
			UtilMgr.AnimatePage(UtilMgr.DIRECTION.ToLeft,
			                    transform.root.FindChild("Lobby").gameObject,
			                    transform.root.FindChild("MyCards").gameObject);
		} else if(name.Equals("BtnUpcoming")){
			
		} else if(name.Equals("BtnLive")){
			
		} else if(name.Equals("BtnRecent")){
			
		}
	}
}
