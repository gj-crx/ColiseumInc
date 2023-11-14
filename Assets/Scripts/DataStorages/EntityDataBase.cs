using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDataBase : IUnitPool
{
    public List<GameObject> AllUnits = new List<GameObject>();

    public bool IsActive { get { return isActive; } }

    private bool isActive = true;

    public List<GameObject> GetStoredUnits()
    {
        return AllUnits;
    }
}
