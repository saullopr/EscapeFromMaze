using System;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour {
    [Range(0, 5)] [SerializeField] private float _minDistance;
    [SerializeField] private int _rayCount = 36;
    [SerializeField] private LayerMask _layerMask;

    public float Distance { get; private set; }
    public bool Collided { get; private set; }

    private void Update() {
        var position = transform.position;
        var minDistance = float.MaxValue;

        foreach (var rayDirection in GetRays()) {
            var hit = Physics.Raycast(position, rayDirection, out var info, _layerMask);

            if (hit && info.distance < minDistance) {
                minDistance = info.distance;
            }
        }

        Collided = minDistance <= _minDistance;
        Distance = minDistance;
    }

    private void OnDrawGizmos() {
        var position = transform.position;

        Gizmos.color = Color.green;
        foreach (var ray in GetRays()) {
            Gizmos.DrawLine(position, position + ray * _minDistance);
        }
    }

    private IEnumerable<Vector3> GetRays() {
        var step = 360f / Math.Max(1, _rayCount);

        for (var i = 0f; i < _rayCount; i++) {
            yield return Quaternion.Euler(0f, i * step, 0f) * transform.forward;
        }
    }
}