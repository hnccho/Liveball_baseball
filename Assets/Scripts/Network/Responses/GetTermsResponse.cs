using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetTermsResponse : BaseResponse {
	string _service1;

	public string service1 {
		get {
			return _service1;
		}
		set {
			_service1 = value;
		}
	}

	string _service2;
	
	public string service2 {
		get {
			return _service2;
		}
		set {
			_service2 = value;
		}
	}

	string _service3;
	
	public string service3 {
		get {
			return _service3;
		}
		set {
			_service3 = value;
		}
	}

	string _personal1;

	public string personal1 {
		get {
			return _personal1;
		}
		set {
			_personal1 = value;
		}
	}

	string _personal2;
	
	public string personal2 {
		get {
			return _personal2;
		}
		set {
			_personal2 = value;
		}
	}
}
