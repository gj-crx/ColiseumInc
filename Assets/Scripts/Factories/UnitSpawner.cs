using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;


public class UnitSpawner
{
    private EntityDataBase dataBase;
    private UnitFactory factory = new UnitFactory();

    [Inject]
    private UnitSpawner(EntityDataBase dataBase)
    {
        this.dataBase = dataBase;
    }

    public Unit SpawnUnit(GameObject prefabOfUnit, Vector3 unitPosition)
    {
        Unit newUnit = factory.Create();
        newUnit.transform.position = unitPosition;

        return newUnit;
    }

    private class UnitFactory : PlaceholderFactory<Unit> { }
}
