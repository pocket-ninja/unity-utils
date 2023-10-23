using System;
using UnityEngine;
using Newtonsoft.Json;

[Serializable]
public struct SerializableVector3 {
    public float x;
    public float y;
    public float z;

    [JsonIgnore]
    public Vector3 vector {
        get { 
            return new Vector3(x, y, z);
        }
        set {
            this.x = value.x;
            this.y = value.y;
            this.z = value.z;    
        }
    }

    public SerializableVector3(Vector3 vector) {
        this.x = vector.x;
        this.y = vector.y;
        this.z = vector.z;
    }

    public SerializableVector3(float x, float y, float z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

public static class Vector3Serializable {
    public static SerializableVector3 Serializable(this Vector3 vector) {
        return new SerializableVector3(vector);
    }
}
