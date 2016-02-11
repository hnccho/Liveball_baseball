using UnityEngine;
using System.Collections;

public class ScriptParticleResizer : MonoBehaviour {

	public void ResizeRatio(float ratio)
	{
		ParticleEmitter[] ArrayEmitter = 
			GetComponentsInChildren<ParticleEmitter>() as ParticleEmitter[]; 
		foreach (ParticleEmitter AEmitter in ArrayEmitter) 
		{ 
			AEmitter.minSize *= ratio;
			AEmitter.maxSize *= ratio;
		}
	}
}
