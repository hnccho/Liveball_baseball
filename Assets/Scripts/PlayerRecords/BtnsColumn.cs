using UnityEngine;
using System.Collections;

public class BtnsColumn : MonoBehaviour {

	public enum SORT{
		ASC,
		DESC
	}
	public SORT mSort = SORT.DESC;
	public bool IsSelected;
	bool FirstInit;

	static Color Gray = new Color(102f/255f,102f/255f,102f/255f);
	static Color Blue = new Color(0,160f/255f,233f/255f);

	// Use this for initialization
	void Start () {
//		if(name.Contains("BtnFP"))
//			IsSelected = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(IsSelected){
			transform.FindChild("Label").GetComponent<UILabel>().color = Blue;
			if(mSort == SORT.ASC){
				transform.FindChild("Down").GetComponent<UISprite>().color = Blue;
				transform.FindChild("Up").GetComponent<UISprite>().color = Gray;
			} else{
				transform.FindChild("Up").GetComponent<UISprite>().color = Blue;
				transform.FindChild("Down").GetComponent<UISprite>().color = Gray;
			}
		} else{
			transform.FindChild("Label").GetComponent<UILabel>().color = Gray;
			transform.FindChild("Down").GetComponent<UISprite>().color = Gray;
			transform.FindChild("Up").GetComponent<UISprite>().color = Gray;
		}
	}

	public void Init(){
		if(!FirstInit
		   && name.Contains("BtnFP")){
			IsSelected = true;
			FirstInit = true;
		}
	}

	public void OnClick(){
		BtnsColumn[] btns = transform.parent.GetComponentsInChildren<BtnsColumn>();
		foreach(BtnsColumn btn in btns)
			btn.IsSelected = false;
		IsSelected = true;

		if(mSort == SORT.ASC)
			mSort = SORT.DESC;
		else
			mSort = SORT.ASC;

		transform.root.FindChild("PlayerRecords").GetComponent<PlayerRecords>().Buildup();
	}
}
