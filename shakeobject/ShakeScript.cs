using System;
using System.Collections;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// ShakeScript Script.
    /// </summary>
    public class ShakeScript : Script
    {
        /// <inheritdoc/>
        /// 
        Transform _target;
        Vector3 _initialPos;

        float _pendingShakeDuration = 0f;

        bool isShaking = false;

        private Task _task;

        public float intensity = 1f;
        public override void OnStart()
        {
            _target = Actor.Transform;
            _initialPos = Actor.LocalPosition;
            Debug.Log("Camera Z position: " + _initialPos.Z.ToString());
        }

        public void Shake(float duration, float strength)
        {
            if (duration > 0)
            {
                intensity = strength;
                _pendingShakeDuration += duration;
            }
        }
        
        /// <inheritdoc/>
        public override void OnEnable()
        {
            _task = Task.Run(DoShake);
        }

        /// <inheritdoc/>
        public override void OnDisable()
        {
            // End async work
            _task.Wait();
        }

        /// <inheritdoc/>
        public override void OnUpdate()
        {
            if (_pendingShakeDuration > 0 && !isShaking)
            {

                _task = Task.Run(AsyncShake);
            }
            
        }

        async Task AsyncShake()
        {
            var startTime = Time.TimeSinceStartup;
            while (Time.TimeSinceStartup < startTime + _pendingShakeDuration)
            {
                DoShake().MoveNext();
            }
            _pendingShakeDuration = 0f;
            Actor.LocalPosition = _initialPos;
            isShaking = false;
        }

       IEnumerator DoShake()
        {
            isShaking = true;
            //Debug.Log("Shake started");
            var startTime = Time.TimeSinceStartup;
            while (Time.TimeSinceStartup < startTime + _pendingShakeDuration)
            {
               // Debug.Log("Shake");
                var rand = new Random();
                var randomPoint = new Vector3( ( (float)rand.NextDouble(-1f, 1f) * intensity)+ _initialPos.X,  ( (float)rand.NextDouble(-1f, 1f) * intensity) + _initialPos.Y, _initialPos.Z);

                Debug.Log("Camera Z position: " + randomPoint.Z.ToString());
                Actor.LocalPosition = randomPoint;
                yield return null;
            }
            

            _pendingShakeDuration = 0f;
            Actor.LocalPosition = _initialPos;
            isShaking = false;

            
        }
    }
}
