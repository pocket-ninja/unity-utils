using System;
using UnityEngine;

public class BehaviourEnable : MonoBehaviour {
    [Serializable]
    public enum EnablePoint: int {
        Awake,
        Start,
        Never
    }

    [SerializeField]
    private EnablePoint _enablePoint;

    [SerializeField]
    private Behaviour _behaviour;

    private void Awake() {
        if (_enablePoint ==  EnablePoint.Awake) {
            _behaviour.enabled = true;
        }
    }

    private void Start() {
        if (_enablePoint ==  EnablePoint.Start) {
            _behaviour.enabled = true;
        }
    }
}
