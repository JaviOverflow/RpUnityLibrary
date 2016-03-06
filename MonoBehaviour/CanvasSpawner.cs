using UnityEngine;
using System.Collections;

public abstract class CanvasSpawner : MonoBehaviour {
    
    protected abstract string PREFAB_PATH { get; }

    protected GameObject _Prefab;
    protected GameObject _Instance;

    void Awake() {
        LoadMenuPrefab();
        WireEvents();
    }

    private void LoadMenuPrefab() {
        _Prefab = Resources.Load<GameObject>(PREFAB_PATH);
    }

    protected abstract void WireEvents();
    protected abstract IEnumerator Show();
    protected abstract IEnumerator Hide();
}
