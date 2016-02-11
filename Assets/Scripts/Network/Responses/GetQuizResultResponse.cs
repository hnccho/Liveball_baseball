using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetQuizResultResponse : BaseResponse {
	QuizResultInfo _data;

	public QuizResultInfo data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}