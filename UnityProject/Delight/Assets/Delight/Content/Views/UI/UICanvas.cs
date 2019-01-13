#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class UICanvas : UIView
    {
        #region Methods

        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            Canvas = GameObject.AddComponent<UnityEngine.Canvas>();
            CanvasScaler = GameObject.AddComponent<UnityEngine.UI.CanvasScaler>();
            GraphicRaycaster = GameObject.AddComponent<UnityEngine.UI.GraphicRaycaster>();
        }

        #endregion
    }
}
