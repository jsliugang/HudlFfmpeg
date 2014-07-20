﻿using System;

namespace Hudl.Ffmpeg.BaseTypes
{
    /// <summary>
    /// class level attribute that sets up a connection between a type with a resource
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    class ForStreamAttribute : Attribute
    {
        public Type Type { get; set; }
    }
}
