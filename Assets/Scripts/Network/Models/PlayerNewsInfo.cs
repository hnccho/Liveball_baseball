using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerNewsInfo  {
	string _content;

	public string content {
		get {
			return _content;
		}
		set {
			_content = value;
		}
	}

	string _title;

	public string title {
		get {
			return _title;
		}
		set {
			_title = value;
		}
	}

	string _newsUrl;

	public string newsUrl {
		get {
			return _newsUrl;
		}
		set {
			_newsUrl = value;
		}
	}

	int _newsId;

	public int newsId {
		get {
			return _newsId;
		}
		set {
			_newsId = value;
		}
	}

	string _newsDate;

	public string newsDate {
		get {
			return _newsDate;
		}
		set {
			_newsDate = value;
		}
	}

	string _newsDay;

	public string newsDay {
		get {
			return _newsDay;
		}
		set {
			_newsDay = value;
		}
	}

	string _newsMonth;

	public string newsMonth {
		get {
			return _newsMonth;
		}
		set {
			_newsMonth = value;
		}
	}

	string _newsWeek;

	public string newsWeek {
		get {
			return _newsWeek;
		}
		set {
			_newsWeek = value;
		}
	}
}
