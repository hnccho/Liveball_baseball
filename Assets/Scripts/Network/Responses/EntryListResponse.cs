using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntryListResponse : BaseResponse {
	List<EntryListInfo> _data;

	public List<EntryListInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
