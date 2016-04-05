using UnityEngine;
using System.Collections;

public class BtnsColumn : MonoBehaviour {

	public enum SORT{
		ASC,
		DESC
	}
	public SORT mSort = SORT.DESC;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(name.Equals("BtnFP")){
			if(mSort == SORT.ASC){
				transform.FindChild("Down").GetComponent<UISprite>().color = new Color(0,160f/255f,233f/255f);
				transform.FindChild("Up").GetComponent<UISprite>().color = new Color(102f/255f,102f/255f,102f/255f);
			} else{
				transform.FindChild("Up").GetComponent<UISprite>().color = new Color(0,160f/255f,233f/255f);
				transform.FindChild("Down").GetComponent<UISprite>().color = new Color(102f/255f,102f/255f,102f/255f);
			}
		} else{
//			if(mSort == SORT.ASC){
//				transform.FindChild("Up").GetComponent<UISprite>().color = new Color(1f,1f,1f);
//				transform.FindChild("Down").GetComponent<UISprite>().color = new Color(102f/255f,102f/255f,102f/255f);
//			} else{
//
//			}
		}
	}

	public void OnClick(){
		if(mSort == SORT.ASC)
			mSort = SORT.DESC;
		else
			mSort = SORT.ASC;

		transform.root.FindChild("PlayerRecords").GetComponent<PlayerRecords>().Buildup();
	}
}
