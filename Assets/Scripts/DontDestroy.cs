using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour 
{
    static DontDestroy instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
	
}
