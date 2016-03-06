using System.Collections;
using UnityEngine;

public static class Motion {

    public static IEnumerator MoveLinearly(Transform transform, Vector3 startPosition, Vector3 endPosition, float movementDuration) {
        float timePassed = 0.0f;
        while (timePassed < movementDuration) {
            timePassed += Time.deltaTime;
            float normalizedTimePassed = timePassed / movementDuration;
            transform.position = Vector3.Lerp(startPosition, endPosition, normalizedTimePassed);
            yield return null;
        }
    }
}
