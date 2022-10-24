﻿using System;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct ModelComponent
    {
        public Transform bodyTransform;
        public Transform cameraTransform;
    }
}