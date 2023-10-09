using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace Installers
{
    public class SpawnersInstaller : MonoInstaller
    {
        [SerializeField] private Unit basicUnitPrefab;
        public override void InstallBindings()
        {
            Container.BindFactory<Unit, UnitSpawner.UnitFactory>().FromComponentInNewPrefab(basicUnitPrefab).AsSingle();
        }
    }
}