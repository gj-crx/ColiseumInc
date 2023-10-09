using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace Installers
{
    public class DataBaseInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EntityDataBase>().FromNew().AsSingle();
        }
    }
}
