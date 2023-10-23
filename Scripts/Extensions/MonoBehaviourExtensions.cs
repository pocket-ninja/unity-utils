using System;
using System.Collections;
using UnityEngine;

public static class MonoBehaviourExtensions {
    public static Coroutine RepeatEvery(this MonoBehaviour mb, float interval, Action task) {
        return mb.StartCoroutine(mb.RepeatEveryCoroutine(interval, task));
    }
    
    public static Coroutine ExecuteAfter(this MonoBehaviour mb, float time, Action task) {
        return mb.StartCoroutine(mb.ExecuteAfterCoroutine(time, task));
    }
    
    public static IEnumerator ExecuteAfterCoroutine(this UnityEngine.MonoBehaviour mb, float time, Action task) {
        yield return new WaitForSeconds(time);
        task?.Invoke();
    }

    public static IEnumerator RepeatEveryCoroutine(this UnityEngine.MonoBehaviour mb, float interval, Action task) {
        while (mb.isActiveAndEnabled) {
            yield return new WaitForSeconds(interval);
            task?.Invoke();
        };
    }
}
