using UnityEngine;
using System.Collections;

public class LiveResultValue : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Init (0, 33);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(int away, int home){
		float oriWidth = 276f;
		int total = away + home;
		//away
		if(away == 0){
			transform.FindChild("Away").FindChild("FG").gameObject.SetActive(false);
		} else{
			transform.FindChild("Away").FindChild("FG").gameObject.SetActive(true);
			float w = (oriWidth / (float)total) * (float)away;		
			transform.FindChild("Away").FindChild("FG").GetComponent<UISprite>().width = (int)w;
			transform.FindChild("Away").FindChild("FG").localPosition = new Vector3((oriWidth - w) / 2f, 0);
		}
		transform.FindChild("Away").FindChild("Label").GetComponent<UILabel>().text = ""+away;
		//home
		if(home == 0){
			transform.FindChild("Home").FindChild("FG").gameObject.SetActive(false);
		} else{
			transform.FindChild("Home").FindChild("FG").gameObject.SetActive(true);
			float w = oriWidth / total * home;		
			transform.FindChild("Home").FindChild("FG").GetComponent<UISprite>().width = (int)w;
			transform.FindChild("Home").FindChild("FG").localPosition = new Vector3(-(oriWidth - w) / 2f, 0);
		}
		transform.FindChild("Home").FindChild("Label").GetComponent<UILabel>().text = ""+home;
	}
}
