using UnityEngine;
using System.Collections;

public class BtnAgree : MonoBehaviour {

	static int mCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		transform.GetComponentInChildren<UILabel>().color = new Color(0f, 160f/255f, 233f/255f);

		if(transform.GetComponent<UIButton>().normalSprite.Equals("btn_checkbox_terms_normal"))
			mCount++;

		transform.GetComponent<UIButton>().normalSprite = "btn_checkbox_terms_hit";
		transform.GetComponent<UIButton>().hoverSprite =  "btn_checkbox_terms_hit";


		if(mCount > 1)
			Next();
	}

	void Next(){
		transform.root.FindChild("Terms").gameObject.SetActive(false);
		transform.root.FindChild("RegisterUsername").gameObject.SetActive(true);
	}
}
