#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ListItem
    {
        #region Properties

        /// <summary>
        /// Parent list the item resides in.
        /// </summary>
        public List ParentList { get; set; }

        /// <summary>
        /// Returns default item style.
        /// </summary>
        public string DefaultItemStyle
        {
            get
            {
                return IsAlternate ? "Alternate" : String.Empty;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnPropertyChanged(object source, string property)
        {
            if (IgnoreObject)
                return;

            base.OnPropertyChanged(source, property);
            switch (property)
            {
                case nameof(IsSelected):
                    IsSelectedChanged();
                    break;
            }
        }

        /// <summary>
        /// Called once in the object's lifetime after construction of children and before load.
        /// </summary>
        public override void AfterInitialize()
        {
            base.AfterInitialize();

            // find parent list
            ParentList = this.FindParent<List>();
        }

        /// <summary>
        /// Called when a child changes its layout.
        /// </summary>
        protected override void ChildLayoutChanged()
        {
            base.ChildLayoutChanged();
            if (IgnoreObject)
                return;

            // the layout of the list item needs to be updated
            LayoutRoot.RegisterChangeHandler(OnListItemChildLayoutChanged);
        }

        /// <summary>
        /// Called when the layout of a child has been changed. 
        /// </summary>
        public void OnListItemChildLayoutChanged()
        {
            // here we want to update the layout but only if size has changed
            if (UpdateLayout(false))
            {
                NotifyParentOfChildLayoutChanged();
            }
        }

        /// <summary>
        /// Updates layout.
        /// </summary>
        public override bool UpdateLayout(bool notifyParent = true)
        {
            bool defaultDisableLayoutUpdate = DisableLayoutUpdate;
            DisableLayoutUpdate = true;

            ElementSize newWidth = Width;
            ElementSize newHeight = Height;

            // adjust width and height to ParentList
            if (ParentList == null || ParentList.Orientation == ElementOrientation.Horizontal)
            {
                newWidth = Width != null && Width.Unit != ElementSizeUnit.Percents ? Width : new ElementSize(Length);

                if (Height == null)
                {
                    newHeight = Breadth != null ? new ElementSize(Breadth) : ElementSize.FromPercents(1);
                }
            }
            else
            {
                // if neither width nor length is set, use 100% width                
                if (Width == null)
                {
                    newWidth = Length != null ? new ElementSize(Length) : ElementSize.FromPercents(1);
                }

                newHeight = Height != null && Height.Unit != ElementSizeUnit.Percents ? Height : new ElementSize(Breadth);
            }

            bool hasNewSize = false;

            // adjust size to content unless it has been set
            if (!newWidth.Equals(Width))
            {
                Width = newWidth;
                hasNewSize = true;
            }
            if (!newHeight.Equals(Height))
            {
                Height = newHeight;
                hasNewSize = true;
            }

            DisableLayoutUpdate = defaultDisableLayoutUpdate;
            return base.UpdateLayout(notifyParent) || hasNewSize;
        }

        /// <summary>
        /// Called when mouse is clicked.
        /// </summary>
        public void ListItemMouseClick()
        {
            if (ParentList == null || State == "Disabled")
                return;

            if (!ParentList.SelectOnMouseUp)
                return;

            SetState("Selected");
            ParentList.SelectItem(this, true);
        }

        /// <summary>
        /// Called when mouse enters.
        /// </summary>
        public void ListItemMouseEnter()
        {
            if (State == "Disabled")
                return;

            IsMouseOver = true;
            if (IsSelected)
                return;

            if (IsPressed)
            {
                SetState("Pressed");
            }
            else
            {
                SetState("Highlighted");
            }
        }

        /// <summary>
        /// Called when mouse exits.
        /// </summary>
        public void ListItemMouseExit()
        {
            if (State == "Disabled")
                return;

            IsMouseOver = false;
            if (IsSelected)
                return;

            SetState(DefaultItemStyle);
        }

        /// <summary>
        /// Called when mouse down.
        /// </summary>
        public void ListItemMouseDown()
        {
            if (ParentList == null || State == "Disabled")
                return;

            if (!ParentList.SelectOnMouseUp)
            {
                SetState("Selected");
                ParentList.SelectItem(this, true);
            }
            else
            {
                IsPressed = true;
                if (IsSelected)
                    return;

                SetState("Pressed");
            }
        }

        /// <summary>
        /// Called when mouse up.
        /// </summary>
        public void ListItemMouseUp()
        {
            if (State == "Disabled")
                return;

            IsPressed = false;
            if (IsSelected)
                return;

            if (IsMouseOver)
            {
                SetState("Highlighted");
            }
            else
            {
                SetState(DefaultItemStyle);
            }
        }

        /// <summary>
        /// Called when the IsSelected field changes.
        /// </summary>
        public virtual void IsSelectedChanged()
        {
            if (State == "Disabled")
                return;

            if (IsSelected)
            {
                SetState("Selected");
            }
            else
            {
                SetState(DefaultItemStyle);
            }
        }

        #endregion
    }
}
