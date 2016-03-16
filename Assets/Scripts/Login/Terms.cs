using UnityEngine;
using System.Collections;

public class Terms : MonoBehaviour {

	GetTermsEvent mTermsEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		gameObject.SetActive(true);
		mTermsEvent = new GetTermsEvent(ReceivedTerms);
		NetMgr.GetTerms(mTermsEvent);
	}

	void ReceivedTerms(){
		UILabel label1 = 
			transform.FindChild("Scroll View").FindChild("Item").FindChild("InfoTerms")
				.FindChild("BGBody").FindChild("Scroll View").FindChild("Label1").GetComponent<UILabel>();
		label1.text = mTermsEvent.Response.service1;
		label1.transform.GetComponent<BoxCollider2D>().size = new Vector2(label1.width, label1.height);
		label1.transform.GetComponent<BoxCollider2D>().offset = new Vector2(0, -(label1.height/2f));
		UILabel label2 =
			transform.FindChild("Scroll View").FindChild("Item").FindChild("InfoTerms")
				.FindChild("BGBody").FindChild("Scroll View").FindChild("Label2").GetComponent<UILabel>();
		label2.text = mTermsEvent.Response.service2;
		label2.transform.localPosition = new Vector3(0, -label1.height, 0);
		label2.transform.GetComponent<BoxCollider2D>().size = new Vector2(label2.width, label2.height);
		label2.transform.GetComponent<BoxCollider2D>().offset = new Vector2(0, -(label2.height/2f));
		UILabel label3 =
			transform.FindChild("Scroll View").FindChild("Item").FindChild("InfoTerms")
				.FindChild("BGBody").FindChild("Scroll View").FindChild("Label3").GetComponent<UILabel>();
		label3.text = mTermsEvent.Response.service3;
		label3.transform.localPosition = new Vector3(0, -(label1.height+label2.height), 0);
		label3.transform.GetComponent<BoxCollider2D>().size = new Vector2(label3.width, label3.height);
		label3.transform.GetComponent<BoxCollider2D>().offset = new Vector2(0, -(label3.height/2f));
		
		transform.FindChild("Scroll View").FindChild("Item").FindChild("InfoTerms")
			.FindChild("BGBody").FindChild("Scroll View").GetComponent<UIScrollView>().ResetPosition();
		//		Debug.Log("1 is "+label1.height + ", 2 is "+label2.height + ", 3 is "+label3.height);
		
		label1 =
			transform.FindChild("Scroll View").FindChild("Item").FindChild("InfoPrivacy")
				.FindChild("BGBody").FindChild("Scroll View").FindChild("Label1").GetComponent<UILabel>();
		label1.text = mTermsEvent.Response.personal1;
		label1.transform.GetComponent<BoxCollider2D>().size = new Vector2(label1.width, label1.height);
		label1.transform.GetComponent<BoxCollider2D>().offset = new Vector2(0, -(label1.height/2f));
		label2 =
			transform.FindChild("Scroll View").FindChild("Item").FindChild("InfoPrivacy")
				.FindChild("BGBody").FindChild("Scroll View").FindChild("Label2").GetComponent<UILabel>();
		label2.text = mTermsEvent.Response.personal2;
		label2.transform.localPosition = new Vector3(0, -label1.height, 0);
		label2.transform.GetComponent<BoxCollider2D>().size = new Vector2(label2.width, label2.height);
		label2.transform.GetComponent<BoxCollider2D>().offset = new Vector2(0, -(label2.height/2f));
		transform.FindChild("Scroll View").FindChild("Item").FindChild("InfoPrivacy")
			.FindChild("BGBody").FindChild("Scroll View").GetComponent<UIScrollView>().ResetPosition();
		
		
	}
}
