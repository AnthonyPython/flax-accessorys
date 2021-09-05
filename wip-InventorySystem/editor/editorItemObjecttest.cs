#if FLAX_EDITOR
using System;
using System.Collections.Generic;
using FlaxEditor.CustomEditors;
using FlaxEditor.CustomEditors.Editors;
using FlaxEngine;

namespace Game
{
    [CustomEditor(typeof(ItemObject))]
    public class MyScriptEditor : GenericEditor
    {

        public JsonAsset ItemObject; //= "Content/itemtest.json";

        
        public override void Initialize(LayoutElementsContainer layout)
        {
            base.Initialize(layout);

            layout.Space(20);
            var button = layout.Button("Click me", Color.Green);

            Debug.Log("Button clicked! The speed is " + (IsSingleObject ? (Values[0] as ItemObject).characterDisplayModel.Name : ""));
            button.Button.Clicked += OnButtonClicked;
            //button.Button.Clicked += () => (Values[0] as ItemObject).OnValidate();//Debug.Log("Button clicked! The speed is " + (IsSingleObject ? (Values[0] as ItemObject).characterDisplayModel.Name : ""));


        }

        private void OnButtonClicked()
        {
            // Create Bonename list
            if((Values[0] as ItemObject).characterDisplayModel)
                (Values[0] as ItemObject).OnValidate();
           

        }
    }
}
#endif