using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoticeResponse : BaseResponse {
	List<NoticeInfo> _data;

	public List<NoticeInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
