using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    public interface IModifier
    {
        void AddValue(ref int baseValue);
    }
}
