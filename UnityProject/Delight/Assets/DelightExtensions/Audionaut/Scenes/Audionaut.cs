#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    public partial class Audionaut
    {
        public void MyHandler(string message)
        {
            Debug.Log("Message");
        }
    }
}
