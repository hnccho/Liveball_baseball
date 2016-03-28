using UnityEngine;
using System.Collections;

public class ItemMyContests : MonoBehaviour {

	public ContestListInfo mContestInfo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		transform.root.FindChild("ContestDetails").GetComponent<ContestDetails>().Init(mContestInfo);
	}
}
