using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DesactiveParticles : MonoBehaviour 
{
    public string poolName;

    void Start()
    {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Particles";
    }
	void Update () 
    {
        if (!GetComponent<ParticleSystem>().isPlaying)
        {
            ObjectsPool.PutInPool(poolName, this.gameObject);
        }
	}
}
