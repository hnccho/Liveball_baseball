using UnityEngine;
using System.Collections;

public class ProgressCircle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Rolling());
	}
	
	IEnumerator Rolling(){
		while (true) {
			transform.eulerAngles-= new Vector3(0,0,45f);
			yield return new WaitForSeconds(0.05f);
		}
	}
}
