using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartUp
{
    /// <summary>
    /// Entry point of the game
    /// </summary>
    public class StartUp : MonoBehaviour
    {
        public GameSettings Settings = new GameSettings();

        private void Awake()
        {
            Settings.ApplySettings();
        }
    }
}
