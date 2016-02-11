using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseCSResponse {

	protected void LogError(string[] error){
		Debug.Log("error code : "+error[1]+", msg : "+error[2]);
	}
}
