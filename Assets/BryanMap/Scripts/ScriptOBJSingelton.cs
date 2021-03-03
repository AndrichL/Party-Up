using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptOBJSingelton<T> : ScriptableObject where T : ScriptableObject
{
    private static T _Instance = null;

    public static T Instance
    { 
       get
       {
            if(_Instance == null)
            {
                T[] Results = Resources.FindObjectsOfTypeAll<T>();

                if(Results.Length == 0)
                {
                    Debug.LogError("ScriptOBJSingelton -> Instance -> Results lenght is 0 for type" + typeof(T).ToString() + ".");
                    return null;

                }
                if (Results.Length > 1)
                {
                    Debug.LogError("ScriptOBJSingelton -> Instance -> Results lenght is more then 1 for type" + typeof(T).ToString() + ".");
                    return null;
                }

                _Instance = Results[0];
            }

            return _Instance;

        }
    }

}
