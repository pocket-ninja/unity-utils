using UnityEngine;

public static class RigidbodyExtensions {
    public static void SimulateTransformPhysics(this Rigidbody rb, float time) { 
        rb.SimulateTransformMovement(time);    
        rb.SimulateTransformRotation(time);
    }

    /// <summary> Simulates the movement of the rigidbody over a specified period of time </summary>
    public static void SimulateTransformMovement(this Rigidbody rb, float time) {
        rb.transform.position += rb.velocity * time;
    }

    /// <summary> Simulates the rotation of the rigidbody over a specified period of time </summary>
    public static void SimulateTransformRotation(this Rigidbody rb, float time) {
        rb.transform.Rotate(rb.angularVelocity * Mathf.Rad2Deg * time, Space.World);
    }

    public static void AddVelocityMagnitude(this Rigidbody rb, float magnitude) {
        rb.SetVelocityMagnitude(Mathf.Max(0, rb.velocity.magnitude + magnitude));
    }

    public static void SetVelocityMagnitude(this Rigidbody rb, float magnitude) {
        rb.velocity = rb.velocity.normalized * magnitude;
    }
}