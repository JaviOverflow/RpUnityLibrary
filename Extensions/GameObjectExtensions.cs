using UnityEngine;

public static class GameObjectExtensions
{
    public static void DestroyChildren(this GameObject gameObject)
    {
        foreach (Transform child in gameObject.transform)
            GameObject.Destroy(child.gameObject);
    }

    public static GameObject InstantiateAsChild(this GameObject gameObject, GameObject prefab)
    {
        GameObject prefabInstance = GameObject.Instantiate(prefab);
        const bool IS_WORLD_POSITIONED = false;
        prefabInstance.transform.SetParent(gameObject.transform, IS_WORLD_POSITIONED);

        return prefabInstance;
    }
}

