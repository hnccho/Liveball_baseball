using UnityEngine;
using System.Collections;

public class ProgressCircle : MonoBehaviour {

	static ProgressCircle _instance;
	GameObject mSprite1;
	GameObject mSprite2;

	// Use this for initialization
	void Start () {
//		StartCoroutine (Rolling());
		mSprite1 = transform.FindChild("BallCenter").FindChild("Sprite1").gameObject;
		mSprite2 = transform.FindChild("BallCenter").FindChild("Sprite2").gameObject;
	}

	void Update(){
		if(gameObject.activeSelf){
			run();
		} else{

		}
	}

	void run(){
		Vector3 ori = mSprite1.transform.localPosition;
		if(ori.y <= -236f)
			mSprite1.transform.localPosition = new Vector3(ori.x, 236f, ori.z);
		else
			mSprite1.transform.localPosition = new Vector3(ori.x, ori.y-10f, ori.z);

		ori = mSprite2.transform.localPosition;
		if(ori.y <= -236f)
			mSprite2.transform.localPosition = new Vector3(ori.x, 236f, ori.z);
		else
			mSprite2.transform.localPosition = new Vector3(ori.x, ori.y-10f, ori.z);

	}

	public static ProgressCircle Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(ProgressCircle)) as ProgressCircle;
				Debug.Log("ProgressCircle is null");
				if (_instance == null)
				{
					GameObject container = new GameObject();  
					container.name = "ProgressCircle";  
					_instance = container.AddComponent(typeof(ProgressCircle)) as ProgressCircle;
					Debug.Log("and makes new one");
					
				}
				
			}
			
			return _instance;
		}
	}
	
	IEnumerator Rolling(){
		while (true) {
			transform.eulerAngles-= new Vector3(0,0,45f);
			yield return new WaitForSeconds(0.05f);
		}
	}
}
