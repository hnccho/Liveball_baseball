// Common funtions

using UnityEngine;
using System.Collections;

public sealed class Com
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








	//--------------- NGUI ----------------------------
    public static UIRoot GetUIRoot()
    {
        if (UIRoot.list != null && UIRoot.list.Count > 0)
        {
            return UIRoot.list[0];
        }
        return null;
    }

    public static Camera NUI_Camera()
    {
        //return UICamera.currentCamera;
        return UICamera.list[0].cachedCamera;
    }

    public static UIButton Find_UIButton(Transform mat, params string[] name)
    {
        Transform find = FindTransform(mat, name);
        if (find)
            return find.GetComponent<UIButton>();
        else
            return null;
    }
    public static UILabel Find_UILabel(Transform mat, params string[] name)
    {
        Transform find = FindTransform(mat, name);
        if (find)
            return find.GetComponent<UILabel>();
        else
            return null;
    }
    public static UISprite Find_UISprite(Transform mat, params string[] name)
    {
        Transform find = FindTransform(mat, name);
        if (find)
            return find.GetComponent<UISprite>();
        else
            return null;
    }
    public static Animator Find_Animator(Transform mat, params string[] name)
    {
        Transform find = FindTransform(mat, name);
        if (find)
            return find.GetComponent<Animator>();
        else
            return null;
    }
    public static Animation Find_Animation(Transform mat, params string[] name)
    {
        Transform find = FindTransform(mat, name);
        if (find)
            return find.GetComponent<Animation>();
        else
            return null;
    }


	// NGUI 하단에 붙이기
    public static void NUI_MoveBottom(Camera cam, Transform mat, float height)
    {
		float uiscale = cam.transform.root.localScale.y;
		Vector3[] poss = NGUITools.GetWorldCorners(cam);
		mat.position = new Vector3(mat.position.x, poss[0].y + height * 0.5f * uiscale, mat.position.z);
    }

    // NGUI 스프라이트 위치를 rate(0 ~ 1) 변경
    public static void NUI_MoveRate(Camera cam, Transform mat, float rx, float ry, float width, float height)
    {
		float uiscale = cam.transform.root.localScale.x;
		Vector3[] poss = NGUITools.GetWorldCorners(cam);
		float sw = Vector3.Distance(poss[0], poss[3]);
		float sh = Vector3.Distance(poss[0], poss[1]);
		float w = width * uiscale;
		float h = height * uiscale;

        float ry2 = 1 - ry;
        Vector3 re = Vector3.zero;
        re.x = (sw * rx) - (w * rx);
        re.y = (sh * ry2) - (h * ry2);
        re.x += -sw * 0.5f + w * 0.5f;
        re.y += -sh * 0.5f + h * 0.5f;
		mat.position = new Vector3(cam.transform.position.x  + re.x, cam.transform.position.y + re.y, mat.position.z);
    }



	//---------------- draw box ----------------

    public static GameObject drawPlane(Vector3 pos, float width, float height)       // Plane 생성
    {
        Mesh m = new Mesh();
        m.name = "ScriptedMesh";
        m.vertices = new Vector3[] {
                new Vector3(-width, -height, 0.01f),
                new Vector3(width, -height, 0.01f),
                new Vector3(width, height, 0.01f),
                new Vector3(-width, height, 0.01f)
            };
        m.uv = new Vector2[] {
                new Vector2 (0, 0),
                new Vector2 (0, 1),
                new Vector2(1, 1),
                new Vector2 (1, 0)
            };
        m.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
        m.RecalculateNormals();

        GameObject plane = new GameObject("Plane");
        MeshFilter meshFilter = (MeshFilter)plane.AddComponent(typeof(MeshFilter));
        meshFilter.mesh = m;
        MeshRenderer renderer = plane.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        renderer.material.color = Color.green;
        plane.transform.position = pos;
        return plane;
    }

    public static GameObject drawCube(Vector3 pos, float size, float seconds, Color color)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.gameObject.GetComponent<Renderer>().material.color = color;
        cube.transform.localScale = new Vector3(size, size, size);
        cube.transform.position = pos;
        cube.GetComponent<Collider>().enabled = false;
        if (seconds > 0)
            GameObject.Destroy(cube, seconds);

        return cube;
    }
    public static GameObject drawCube(Vector3 pos, float size = 1, float seconds = 0)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(size, size, size);
        cube.transform.position = pos;
        cube.GetComponent<Collider>().enabled = false;
        if (seconds > 0)
            GameObject.Destroy(cube, seconds);

        return cube;
    }

    public static GameObject CubeLine(Vector3 pos1, Vector3 pos2, float size, Color color, float seconds = 0)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = pos1;
        //cube.transform.gameObject.renderer.material.color = color;
        //cube.collider.enabled = false;

        Vector3 dir = pos1 - pos2;
        float dis = dir.magnitude;
        dir = dir.normalized;

        cube.transform.localScale = new Vector3(size, size, dis);
        cube.transform.LookAt(pos2);
        cube.transform.position = pos1 - dis * dir * 0.5f;

        if (seconds > 0)
            GameObject.Destroy(cube, seconds);

        return cube;
    }

}
