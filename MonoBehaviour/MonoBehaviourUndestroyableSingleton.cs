using UnityEngine;

/*
 * Inheriting from this class will convert child into undestroyable (not destroying on switching
 *  scenes) singleton.
 *
 *  - NOTE: If you implement on child class Awake() method, add the following line in Awake()
 *      child method body. This will prevent from executing Awake() child method if instance was 
 *      marked to be destroyed, which happens while reloading scene where child is declared.
 *                      [CODE]  base.Awake(); if (_destroyed) return;  [\CODE]
 */
public class MonoBehaviourUndestroyableSingleton<T> : MonoBehaviour where T : MonoBehaviourUndestroyableSingleton<T> {
    protected static T instance;
    protected bool _destroyed = false;

    public static T Instance {
        get {
            if (instance == null) 
                InitSingletonInstance();

            return instance;
        }
    }

    protected void Awake() {
        if (instance == null) 
            InitSingletonInstance();

        if (this != instance) {
            Destroy(gameObject);
            _destroyed = true;
        }
    }

    protected static void InitSingletonInstance() {
        instance = (T) FindObjectOfType(typeof(T));

        if (instance != null) {
            DontDestroyOnLoad(instance);
        } else {
            Debug.LogError("An instance of " + typeof(T) + 
                " is needed in the scene, but there is none.");
        }

    }
}
