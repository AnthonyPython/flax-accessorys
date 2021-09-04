using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    /// <summary>
    /// ShakeTest Script.
    /// </summary>
    /// 

    public class ShakeTest : Script
    {
        public ShakeScript Shaker;
        public float duration = 1f;
        public float strength = 1f;
        /// <inheritdoc/>
        public override void OnStart()
        {
            // Here you can add code that needs to be called when script is created, just before the first game update
        }
        
        /// <inheritdoc/>
        public override void OnEnable()
        {
            // Here you can add code that needs to be called when script is enabled (eg. register for events)
        }

        /// <inheritdoc/>
        public override void OnDisable()
        {
            // Here you can add code that needs to be called when script is disabled (eg. unregister from events)
        }

        /// <inheritdoc/>
        public override void OnUpdate()
        {
            if (Input.GetKeyUp(KeyboardKeys.T))
            {
                Shaker.Shake(duration, strength);
            }
        }
    }
}
