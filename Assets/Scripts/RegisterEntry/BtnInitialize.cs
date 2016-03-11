using UnityEngine;
using System.Collections;

public class BtnInitialize : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnClick(){
		UISprite sprite = transform.FindChild("Sprite").GetComponent<UISprite>();
		sprite.color = new Color(1f, 1f, 1f, 1f);
		sprite.transform.localPosition = new Vector3(66f, -4f, 0f);
		
		UILabel label = transform.FindChild("LblInitialize").GetComponent<UILabel>();
		label.transform.localPosition = new Vector3(36f, -4f, 0f);
		
		sprite = transform.FindChild("Background").GetComponent<UISprite>();
		sprite.flip = UIBasicSprite.Flip.Vertically;
		
		StartCoroutine("BtnAnim");
	}
	
	IEnumerator BtnAnim()
	{
		yield return new WaitForSeconds(0.5f);
		
		UISprite sprite = transform.FindChild("Sprite").GetComponent<UISprite>();
		sprite.color = new Color(1f, 1f, 1f, 150f/255f);
		sprite.transform.localPosition = new Vector3(66f, 0f, 0f);
		
		UILabel label = transform.FindChild("LblInitialize").GetComponent<UILabel>();
		label.transform.localPosition = new Vector3(36f, 0f, 0f);
		
		sprite = transform.FindChild("Background").GetComponent<UISprite>();
		sprite.flip = UIBasicSprite.Flip.Nothing;
	}
}
