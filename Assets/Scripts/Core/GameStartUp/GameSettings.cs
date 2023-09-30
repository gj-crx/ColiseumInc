using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartUp
{
    [System.Serializable]
    public class GameSettings
    {
        private int targetFrameRate = 45;

        public void ApplySettings()
        {
            Application.targetFrameRate = targetFrameRate;
        }
    }
}
