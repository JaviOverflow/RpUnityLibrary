using UnityEngine;
using System.Collections;

public static class Scale {

    public static IEnumerator Shrink(Transform transform, float time) {
        const float EDGE_COLLIDER_ISSUE = 0.05f;
        Vector3 initialScale = transform.localScale;
        float timeLeft = time;
        while (timeLeft > 0f) {
            timeLeft -= Time.deltaTime;
            transform.localScale = (timeLeft/time + EDGE_COLLIDER_ISSUE) * initialScale;
            yield return null;
        }
    }
}
