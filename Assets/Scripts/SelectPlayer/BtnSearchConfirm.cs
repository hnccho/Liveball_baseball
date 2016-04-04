using UnityEngine;
using System.Collections;

public class BtnSearchConfirm : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		if(name.Equals("BtnSearch")){
			transform.parent.FindChild("Input").gameObject.SetActive(true);
			transform.parent.FindChild("BtnConfirm").gameObject.SetActive(true);
			transform.parent.FindChild("LblTitle").gameObject.SetActive(false);
			transform.parent.FindChild("BtnSearch").gameObject.SetActive(false);
			transform.parent.FindChild("Input").GetComponent<UIInput>().defaultText
				= UtilMgr.GetLocalText("StrInputPlayerName");
			transform.parent.FindChild("Input").GetComponent<UIInput>().value = "";
		} else{
			transform.parent.FindChild("Input").gameObject.SetActive(false);
			transform.parent.FindChild("BtnConfirm").gameObject.SetActive(false);
			transform.parent.FindChild("LblTitle").gameObject.SetActive(true);
			transform.parent.FindChild("BtnSearch").gameObject.SetActive(true);	
			transform.root.FindChild("SelectPlayer").GetComponent<SelectPlayer>().
				Search(transform.parent.FindChild("Input").GetComponent<UIInput>().value);
		}

	}
}
