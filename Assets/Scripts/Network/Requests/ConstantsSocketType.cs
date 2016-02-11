using UnityEngine;
using System.Collections;
using System.Text;

namespace ConstantsSocketType{
	public class REQ{
		public const int TYPE_JOIN = 5001;
		public const int TYPE_ALIVE = 7000;
	}

	public class RES{
		public const int TYPE_JOIN = 5001;
		public const int TYPE_ALIVE = 7000;
		public const int TYPE_STATUS = 5011;
		public const int TYPE_START = 5021;
		public const int TYPE_CLOSE = 5022;
	}
}
