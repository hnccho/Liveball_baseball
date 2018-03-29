using UnityEngine;
using System.Collections;

public class Bingo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Texture2D texture = null;
		if(UtilMgr.IsMLB())
			texture = Resources.Load<Texture2D>("images/rt_bingo_comingsoon");
		else
			texture = Resources.Load<Texture2D>("images/rt_bingo_comingsoon_k");
			
		transform.FindChild("Body").FindChild("Scroll View").GetChild(0).GetComponent<UITexture>().mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
