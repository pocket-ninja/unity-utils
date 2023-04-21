using UnityEngine;

[ExecuteAlways]
public class CameraDepthTextureMode : MonoBehaviour {
    [SerializeField]
    private DepthTextureMode mode;

    [SerializeField]
    private Camera target;

    private void Start() {
        SetupMode();
    }

    private void OnValidate() { 
        SetupMode();
    }

    private void SetupMode() {
        target.depthTextureMode = mode;
    }
}
