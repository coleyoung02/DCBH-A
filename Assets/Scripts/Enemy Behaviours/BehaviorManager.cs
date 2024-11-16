using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BehaviorManager : MonoBehaviour
{
    List<IBehaviour> _behaviours = new List<IBehaviour>();
    IBehaviour _currentBehavior;
    // Start is called before the first frame update
    void Awake()
    {
        _behaviours = GetComponents<IBehaviour>().ToList();
        _currentBehavior = _behaviours.First();
    }

    private void OnEnable() 
    {
        foreach (var b in _behaviours)
        {
            b.OnStateChanged += HandleOnStateChanged;
        }
    }
    
     private void Disable() 
    {
        foreach (var b in _behaviours)
        {
            b.OnStateChanged -= HandleOnStateChanged;
        }
    }
    void HandleOnStateChanged()
    {
        _currentBehavior = _behaviours.FindLast (b => b.IsActive);
    }
    void Update()
    {
        _currentBehavior.Tick();
    }
}
