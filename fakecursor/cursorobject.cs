using System;
using System.Collections.Generic;
using FlaxEngine.GUI;
using FlaxEngine;

namespace Game
{
    /// <summary>
    /// cursorobject Script.
    /// </summary>
    /// 


    public class cursorobject : Script 
    {
        

        private Image _testimage;

        public TextureBrush Cursor;

        public Margin image_margin;

        public static cursorobject Instance;

        /// <inheritdoc/>
        public override void OnAwake()
        {
            if (Instance != this)
            {
                Destroy(Instance);
                Instance = this;
            }
        }

        /// <inheritdoc/>
        public override void OnStart()
        {
           

            // Here you can add code that needs to be called when script is created, just before the first game update
        }

        public override void OnEnable()
        {
            _testimage = new Image
            {
                Width = 64,
                Height = 64,
                Parent = RootControl.GameRoot,
                Brush = Cursor,
                Pivot = new Vector2(0.5f, 0.5f),
                Offsets = image_margin,
            };
            
        }


        public void setCursorImage(TextureBrush image)
        {
            _testimage.Brush = image;
        }
        public override void OnDisable()
        {
            _testimage.Dispose();
            _testimage = null;
        }

        /// <inheritdoc/>
        public override void OnUpdate()
        {

            var pos = Input.MousePosition;

            

            _testimage.X = pos.X;
            _testimage.Y = pos.Y;


        }
    }
}
