using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Thruster : MonoBehaviour
{
    public float power;

    private float throttle;

    public float Throttle
    {
        get { return throttle; }
        set { throttle = Mathf.Clamp01(value); }
    }

    protected bool ShouldApplyThrottle { get { return !Mathf.Approximately(power * Throttle, 0.0f); } }

    public abstract void ApplyThrottle();

    void Update()
    {
        if (ShouldApplyThrottle) {
            ApplyThrottle();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = ShouldApplyThrottle ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (-transform.up * power));
    }
}
