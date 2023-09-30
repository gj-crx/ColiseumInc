using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDataBase : IUnitPool
{
    public List<Unit> AllUnits = new List<Unit>();

    public bool IsActive { get { return isActive; } }

    private bool isActive = true;

    public List<Unit> GetStoredUnits()
    {
        return AllUnits;
    }
}
