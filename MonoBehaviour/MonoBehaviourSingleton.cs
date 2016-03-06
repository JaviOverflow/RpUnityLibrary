using UnityEngine;

/*
 * Inheriting from this class will convert child into singleton. 
 *  NOTE: Instance will be destroyed when switching scene.
 */
public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviourSingleton<T> {
    protected static T instance;

    public static T Instance {
        get {
            if(instance == null)
                InitSingletonInstance();

            return instance;
        }
    }

    protected static void InitSingletonInstance() {
        instance = (T) FindObjectOfType(typeof(T));

        if (instance == null) {
            Debug.LogError("An instance of " + typeof(T) + 
                " is needed in the scene, but there is none.");
        }
    }

}
