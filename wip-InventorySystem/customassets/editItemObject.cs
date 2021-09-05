using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    /// <summary>
    /// editItemObject Script.
    /// </summary>
    public class editItemObject : Script
    {
        /// <inheritdoc/>
        public JsonAsset ItemObject;

        public AnimatedModel ModelToUse;

        public override void OnStart()
        {
            if (ItemObject)
            {
                var obj = (ItemObject)ItemObject.CreateInstance();
                //obj.characterDisplayModel = ModelToUse;
                obj.OnValidate();
                Debug.Log("Model used: " + obj.characterDisplayModel.Name);
                Debug.Log("Bone names: " + obj.boneNames.Count);
            }
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
            // Here you can add code that needs to be called every frame
        }
    }
}
