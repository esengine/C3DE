﻿using C3DE.Components.Colliders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace C3DE.Editor.Controls
{
    /// <summary>
    /// Interaction logic for BoxColliderControl.xaml
    /// </summary>
    public partial class ColliderControl : UserControl
    {
        private Collider _collider;

        public bool Enabled
        {
            get
            {
                if (_collider != null)
                    return _collider.Enabled;

                return false;
            }
            set
            {
                if (_collider != null)
                    _collider.Enabled = value;
            }
        }

        public float SizeX
        {
            get
            {
                if (_collider != null)
                    return _collider.Size.X;

                return 0;
            }
            set
            {
                if (_collider != null)
                    _collider.SetSize(value, null, null);
            }
        }

        public float SizeY
        {
            get
            {
                if (_collider != null)
                    return _collider.Size.Y;

                return 0;
            }
            set
            {
                if (_collider != null)
                    _collider.SetSize(null, value, null);
            }
        }

        public float SizeZ
        {
            get
            {
                if (_collider != null)
                    return _collider.Size.Z;

                return 0;
            }
            set
            {
                if (_collider != null)
                    _collider.SetSize(null, null, value);
            }
        }

        public float CenterX
        {
            get
            {
                if (_collider != null)
                    return _collider.Center.X;

                return 0;
            }
            set
            {
                if (_collider != null)
                    _collider.SetCenter(value, null, null);
            }
        }

        public float CenterY
        {
            get
            {
                if (_collider != null)
                    return _collider.Center.Y;

                return 0;
            }
            set
            {
                if (_collider != null)
                    _collider.SetCenter(null, value, null);
            }
        }

        public float CenterZ
        {
            get
            {
                if (_collider != null)
                    return _collider.Center.Z;

                return 0;
            }
            set
            {
                if (_collider != null)
                    _collider.SetCenter(null, null, value);
            }
        }

        public bool IsTriger
        {
            get
            {
                if (_collider != null)
                    return _collider.IsTrigger;

                return false;
            }
            set
            {
                if (_collider != null)
                    _collider.IsTrigger = value;
            }
        }

        public bool IsPickable
        {
            get
            {
                if (_collider != null)
                    return _collider.IsPickable;

                return false;
            }
            set
            {
                if (_collider != null)
                    _collider.IsPickable = value;
            }
        }

        public int ColliderType
        {
            get
            {
                if (_collider != null)
                    return _collider is BoxCollider ? 0 : 1;

                return 0;
            }
            set
            {
                if (_collider != null)
                {
                    var sceneObject = _collider.SceneObject;
                    var size = _collider.Size;
                    var center = _collider.Center;
                    var pick = _collider.IsPickable;
                    var trigger = _collider.IsTrigger;

                    sceneObject.RemoveComponent(_collider);

                    if (value == 0)
                        _collider = sceneObject.AddComponent<BoxCollider>();
                    else
                        _collider = sceneObject.AddComponent<SphereCollider>();

                    _collider.Size = size;
                    _collider.Center = center;
                    _collider.IsPickable = pick;
                    _collider.IsTrigger = trigger;
                }
            }
        }

        public ColliderControl()
        {
            InitializeComponent();
        }

        public ColliderControl(Collider collider)
            : this()
        {
            _collider = collider;
            DataContext = this;
        }
    }
}