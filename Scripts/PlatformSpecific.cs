using System;
using UnityEngine;

[Serializable]
public struct PlatformSpecific<T> {
    [field: SerializeField]
    public T ios { get; set; }

    [field: SerializeField]
    public T android { get; set; }

    [field: SerializeField]
    public T editor { get; set; }

    public T value {
        get {
#if UNITY_EDITOR
            return editor;
#elif UNITY_ANDROID
            return android;
#elif UNITY_IOS
            return ios;
#else
            return editor;
#endif
        }
    }

    public PlatformSpecific(T ios, T android, T editor) {
        this.ios = ios;
        this.android = android;
        this.editor = editor;
    }
}
