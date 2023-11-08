using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitPool
{
    bool IsActive { get; }
    List<GameObject> GetStoredUnits();
}
