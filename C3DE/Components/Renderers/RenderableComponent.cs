﻿using C3DE.Components.Colliders;
using C3DE.Materials;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace C3DE.Components.Renderers
{
    /// <summary>
    /// An abstract class to define a renderable object.
    /// </summary>
    public abstract class RenderableComponent : Component
    {
        protected internal BoundingSphere boundingSphere;
        protected internal List<int> materials;
        protected internal int materialCount;

        public bool CastShadow { get; set; }
        public bool RecieveShadow { get; set; }

        protected internal List<int> MaterialIndices
        {
            get { return materials; }
        }

        public Material Material
        {
            get { return materialCount > 0 ? sceneObject.Scene.Materials[materials[0]] : null; }
            set { AddMaterial(value); }
        }

        public int MaterialCount
        {
            get { return materialCount; }
        }

        public BoundingSphere BoundingSphere
        {
            get { return boundingSphere; }
            protected set { boundingSphere = value; }
        }

        public RenderableComponent()
            : base()
        {
            CastShadow = true;
            RecieveShadow = true;
            boundingSphere = new BoundingSphere();
            materials = new List<int>(1);
            materialCount = 0;
        }

        public void AddMaterial(Material material)
        {
            if (sceneObject.Scene == null)
                sceneObject.Scene = material.scene;

            var index = material.Index;

            if (materials.IndexOf(index) == -1)
            {
                materials.Add(material.Index);
                materialCount++;
            }
        }

        public void RemoveMaterial(Material material)
        {
            var index = material.Index;

            if (materials.IndexOf(index) > -1)
            {
                materials.Remove(index);
                materialCount--;
            }
        }

        protected void UpdateColliders()
        {
            var colliders = GetComponents<Collider>();
            var size = colliders.Length;

            if (size > 0)
            {
                for (var i = 0; i < size; i++)
                    colliders[i].Compute();
            }
        }

        public abstract void ComputeBoundingSphere();

        public abstract void Draw(GraphicsDevice device);
    }
}
