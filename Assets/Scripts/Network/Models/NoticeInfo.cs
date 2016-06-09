using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoticeInfo {
	string _title;
	public string title {
		get {
			return _title;
		}
		set {
			_title = value;
		}
	}

//"테스트중~~",
	string _linkUrl;
	public string linkUrl {
		get {
			return _linkUrl;
		}
		set {
			_linkUrl = value;
		}
	}

//"",
	string _announce;
	public string announce {
		get {
			return _announce;
		}
		set {
			_announce = value;
		}
	}

//"현재 테스중입니다.",
	string _link;
	public string link {
		get {
			return _link;
		}
		set {
			_link = value;
		}
	}

//"N",
	string _attached;
	public string attached {
		get {
			return _attached;
		}
		set {
			_attached = value;
		}
	}

//"http://mng.rankingball.com/asset/contents/events/ev_1463463306.jpg",
	int _seq;
	public int seq {
		get {
			return _seq;
		}
		set {
			_seq = value;
		}
	}

//10,
	int _pop_close;
	public int pop_close {
		get {
			return _pop_close;
		}
		set {
			_pop_close = value;
		}
	}

//0,
	string _wdate;
	public string wdate {
		get {
			return _wdate;
		}
		set {
			_wdate = value;
		}
	}

//"20160517143506",
	int _pop_open;
	public int pop_open {
		get {
			return _pop_open;
		}
		set {
			_pop_open = value;
		}
	}

//0,
	string _pop;
	public string pop {
		get {
			return _pop;
		}
		set {
			_pop = value;
		}
	}

//"N",
	string _url;//"http://mng.rankingball.com/announce/vu/10"

	public string url {
		get {
			return _url;
		}
		set {
			_url = value;
		}
	}
}
