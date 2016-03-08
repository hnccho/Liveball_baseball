using UnityEngine;
using System.Collections;

public class ProgressCircle : MonoBehaviour {

	static ProgressCircle _instance;
	GameObject mSprBall1;
	GameObject mSprBall2;
	GameObject mSprBorder1;
	bool mBorderFill;

	// Use this for initialization
	void Start () {
//		StartCoroutine (Rolling());
		mSprBall1 = transform.FindChild("BallCenter").FindChild("Sprite1").gameObject;
		mSprBall2 = transform.FindChild("BallCenter").FindChild("Sprite2").gameObject;
		mSprBorder1 = transform.FindChild("Border").FindChild("Sprite1").gameObject;
	}

	void Update(){
		if(gameObject.activeSelf){
			run();
		} else{

		}
	}

	void run(){
		Vector3 ori = mSprBall1.transform.localPosition;
		if(ori.y <= -236f)
			mSprBall1.transform.localPosition = new Vector3(ori.x, 236f, ori.z);
		else
			mSprBall1.transform.localPosition = new Vector3(ori.x, ori.y-10f, ori.z);

		ori = mSprBall2.transform.localPosition;
		if(ori.y <= -236f)
			mSprBall2.transform.localPosition = new Vector3(ori.x, 236f, ori.z);
		else
			mSprBall2.transform.localPosition = new Vector3(ori.x, ori.y-10f, ori.z);

		UISprite sprBorder = mSprBorder1.GetComponent<UISprite>();
		if(sprBorder.fillAmount == 0f){
			mBorderFill = true;
			sprBorder.invert = true;
		} else if(sprBorder.fillAmount == 1f){
			mBorderFill = false;
			sprBorder.invert = false;
		}

		if(mBorderFill){
			sprBorder.fillAmount += 10f/360f;
			if(sprBorder.fillAmount > 1f) sprBorder.fillAmount = 1f;
		} else{
			sprBorder.fillAmount -= 10f/360f;
			if(sprBorder.fillAmount < 0f) sprBorder.fillAmount = 0f;
		}
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
