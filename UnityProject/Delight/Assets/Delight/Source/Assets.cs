﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UniRx.Async;
using UnityEngine;
#endregion

namespace Delight
{
    public static partial class Assets
    {
        public static string ServerUri;
        public static ServerUriLocator ServerUriLocator = new ServerUriLocator();
    }
}
