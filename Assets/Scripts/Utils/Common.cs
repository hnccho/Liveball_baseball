// Common funtions

using UnityEngine;
using System.Collections;

public sealed class Common
{

	public static void LOOG(params object[] obj)
	{
		if (Application.isEditor == false) return;                  // 에디터에서만 나오게 하자
		
		object ret = "";
		for (int i = 0; i < obj.Length; i++)
		{
			ret = ret + "  " + obj[i];
		}
		Debug.Log(ret);                     // 이 로그는 그냥 출력하자		
	}





	static Transform FindTransformDontRoot(Transform root, Transform target, string name)            // 자기 자신은 검색에서 제외
	{
		if (target == null) return null;
		
		if (target.name == name && root != target) return target;
		
		for (int i = 0; i < target.childCount; ++i)
		{
			Transform result = FindTransformDontRoot(root, target.GetChild(i), name);
			if (result != null) return result;
		}
		return null;
	}
	//부모name->자식name이다...Active되어있지 않는것도 찾는다...만약 못찾으면 null 리턴...참고로 좀더 정확하게 찾으려면 transform.Find("General_TopBg/BG/Soulstones") 함수를 이용하자
	static Transform find_temp;
	public static Transform FindTransform(Transform target, params string[] name)
	{
		Transform find = target;
		bool seek = false;
		for (int i = 0; i < name.Length; i++)
		{
			seek = false;
			find_temp = find.FindChild(name[i]);            //[좀더최적화]..바로 하위자식 위주로 찾는다
			if (find_temp)
			{
				find = find_temp; seek = true;
			}
			
			if (seek == false)
			{
				find = FindTransformDontRoot(find, find, name[i]);
				if (find == null) break;
			}
		}
		return find;
	}
	static public Transform FindParent(Transform go, string name)
	{
		if (go == null) return null;
		Transform t = go;
		while (t != null)
		{
			t = t.parent;
			if (t && t.name == name) return t;
		}
		return null;
	}
	
	public static T FindParent<T>(Transform mat) where T : Component
	{
		if (mat == null) return null;
		Transform t = mat;
		while (t != null)
		{
			t = t.parent;
			T comp = t.GetComponent<T>();
			if (t && comp != null) return comp;
		}
		return null;
	}

}
