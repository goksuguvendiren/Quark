﻿using System.Collections.Generic;
using Quark.Attributes;
using System.Collections;

namespace Quark
{
    public class Interaction : IEnumerable<AttributeModifier>
    {
        readonly List<AttributeModifier> _modifiers;

        /// <summary>
        /// Initialize a new effect collection
        /// </summary>
        public Interaction()
        {
            _modifiers = new List<AttributeModifier>();
        }

        /// <summary>
        /// Add a new interaction to this collection
        /// </summary>
        /// <param name="modifier">The interaction to be added</param>
        public void Add(AttributeModifier modifier)
        {
            _modifiers.Add(modifier);
        }

        public void Add (string tag, float multiplier)
        {
            _modifiers.Add(new AttributeModifier(tag, multiplier));
        }

        public IEnumerator<AttributeModifier> GetEnumerator()
        {
            return _modifiers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _modifiers.GetEnumerator();
        }
 
        /// <summary>
        /// Calculates the current value of this Interaction for a given Character
        /// </summary>
        /// <param name="of"></param>
        /// <returns></returns>
        public float Calculate(Character of)
        {
            float val = 0;
            foreach (AttributeModifier interaction in _modifiers)
                val += interaction.GetValue(of);
            return val;
        }
    }
}

