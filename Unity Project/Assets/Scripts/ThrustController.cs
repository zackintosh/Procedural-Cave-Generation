using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ThrustController : MonoBehaviour
{
    [System.Serializable]
    public struct ThrusterGroup
    {
        public string name;
        public Thruster[] thrusters;
    }

    public ThrusterGroup[] thrusterGroups;

    private Dictionary<Thruster, bool> thrusterActivationMap = new Dictionary<Thruster, bool>();
    private HashSet<Thruster> thrusters = new HashSet<Thruster>();

    private void Start()
    {
        foreach (var thrusterGroup in thrusterGroups) {
            foreach (var thruster in thrusterGroup.thrusters) {
                thrusterActivationMap[thruster] = false;
                thrusters.Add(thruster);
            }
        }
    }

    private void Update()
    {
        foreach (var thrusterKey in thrusters) {
            thrusterActivationMap[thrusterKey] = false; 
        }

        foreach (var thrusterGroup in thrusterGroups) {
            bool activateThruster = Input.GetKey(thrusterGroup.name) || Input.GetKeyDown(thrusterGroup.name) ;
            
            foreach (var thrusterKey in thrusterGroup.thrusters) {
                thrusterActivationMap[thrusterKey] = activateThruster || thrusterActivationMap[thrusterKey]; 
            }
        }

        foreach (var kvp in thrusterActivationMap) {
            kvp.Key.Throttle = (kvp.Value ? 1.0f : 0.0f);
        }
    }
}
