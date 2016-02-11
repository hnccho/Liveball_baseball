using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuizResultInfo {
	List<QuizResultGlobal> _global;
	
	public List<QuizResultGlobal> global {
		get {
			return _global;
		}
		set {
			_global = value;
		}
	}
	
	List<QuizResultGlobal> _friend;
	
	public List<QuizResultGlobal> friend {
		get {
			return _friend;
		}
		set {
			_friend = value;
		}
	}
	
	List<QuizResultResults> _result;
	
	public List<QuizResultResults> result {
		get {
			return _result;
		}
		set {
			_result = value;
		}
	}
}
