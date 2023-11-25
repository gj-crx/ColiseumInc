using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;


public class UnitSpawner
{
    private EntityDataBase dataBase;
    private UnitFactory factory;

    [Inject]
    private UnitSpawner(EntityDataBase dataBase, UnitFactory factory)
    {
        this.dataBase = dataBase;
        this.factory = factory;
    }

    public Unit SpawnUnit(GameObject prefabOfUnit, Vector3 unitPosition)
    {
        Unit newUnit = factory.Create();
        newUnit.transform.position = unitPosition;

        dataBase.AllUnits.Add(newUnit);

        return newUnit;
    }

    internal class UnitFactory : PlaceholderFactory<Unit> { }
}
