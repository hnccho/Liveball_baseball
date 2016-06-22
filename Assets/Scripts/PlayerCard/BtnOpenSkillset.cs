using UnityEngine;
using System.Collections;

public class BtnOpenSkillset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		transform.root.FindChild("SkillList").GetComponent<SkillList>().Init(
			transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().mCardInfo);
		transform.root.FindChild("PlayerCard").gameObject.SetActive(false);
	}
}
