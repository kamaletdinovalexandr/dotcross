using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component {
    static T instance;

    public static T Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<T>();
                if (instance == null) {
                    Debug.LogError(typeof(T).ToString() + " is null");
                }
            }
           
            return instance;
        }
    }

    private void Awake() {
        if (instance == null) {
            instance = this as T;
        }
        
        Init();
    }

    internal virtual void Init() { }
}
