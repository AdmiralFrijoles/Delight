#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Provides logic for switching between views. 
    /// </summary>
    public partial class ViewSwitcher
    {
        #region Fields

        public SceneObjectView ActiveView;

        #endregion

        #region Methods

        /// <summary>
        /// Called before the view is loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            if (IgnoreObject)
                return;
            base.BeforeLoad();

            var firstChild = Content.LayoutChildren.FirstOrDefault();

            // make sure load-mode is set to Manual in children
            foreach (SceneObjectView child in Content.LayoutChildren)
            {
                if (!String.IsNullOrEmpty(StartView) && child.Id.IEquals(StartView))
                {
                    ActiveView = child;
                    continue;
                }

                if (SwitchToDefault && child == firstChild)
                {
                    ActiveView = child;
                    continue;
                }

                if (SwitchMode != SwitchMode.Enable)
                {
                    child.LoadMode = LoadMode.Manual;
                }
                else
                {
                    child.IsActive = false;
                }
            }

        }

        /// <summary>
        /// Called after the view is loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            if (IgnoreObject)
                return;
            base.AfterLoad();

            // load active view if it hasn't been loaded
            if (ActiveView != null)
            {
                if (!ActiveView.IsLoaded)
                    ActiveView.Load();

                if (!ActiveView.IsActive)
                    ActiveView.IsActive = true;
            }
        }

        /// <summary>
        /// Switches to view at index.
        /// </summary>
        public void SwitchTo(int index)
        {
            var view = Content.LayoutChildren.ElementAtOrDefault(index);
            SwitchTo(view);
        }

        /// <summary>
        /// Switches to the view specified.
        /// </summary>
        public void SwitchTo(View view)
        {
            if (view == ActiveView)
                return;

            if (ActiveView != null)
            {
                if (SwitchMode == SwitchMode.Load)
                {
                    ActiveView.Unload();
                }
                else
                {
                    ActiveView.IsActive = false;
                }
            }

            ActiveView = view as SceneObjectView;
            if (ActiveView == null)
                return;

            if (SwitchMode == SwitchMode.Enable)
            {
                ActiveView.IsActive = true;
            }
            else
            {
                ActiveView.Load();
            }
        }

        #endregion
    }
}
