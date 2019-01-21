﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    /// <summary>
    /// Generic collection view.
    /// </summary>
    public partial class Collection
    {
        #region Properties

        public Func<BindableObject, View> ItemInitializer;
        private BindableCollection _oldCollection;

        #endregion

        #region Constructor

        //public CollectionView(View parent = null, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
        //    base(parent, layoutParent, id, template ?? ListViewTemplates.Default, initializer)
        //{
        //}

        #endregion

        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnPropertyChanged(object source, string property)
        {
            base.OnPropertyChanged(source, property);
            if (property == ItemsProperty.PropertyName)
            {
                ItemsChanged();
            }
        }

        /// <summary>
        /// Called when the list of items has been replaced.
        /// </summary>
        public virtual void ItemsChanged()
        {
            if (_oldCollection != null)
            {
                // unsubscribe from change events in the old list
                _oldCollection.CollectionChanged -= OnCollectionChanged;
            }
            _oldCollection = Items;

            // add new list
            if (Items != null)
            {
                // subscribe to change events in the new list
                Items.CollectionChanged += OnCollectionChanged;
            }

            // unload and clear existing children
            foreach (var child in _layoutChildren)
            {
                child.Unload();
            }
            _layoutChildren.Clear();

            if (IsLoaded)
            {
                GenerateItems();
            }
        }

        protected void GenerateItems()
        {
            if (Items == null)
                return;

            // TODO the view template needs to be supplied somehow
            foreach (var item in Items.GetDataEnumerator())
            {
                // create new children
                GenerateItem(item);
            }

        }

        private void GenerateItem(BindableObject item)
        {
            var itemView = ItemInitializer(item) as UIView;
            itemView.Load();
            itemView.Offset = new ElementMargin(0, LayoutChildren.Count * 35, 0, 0);
        }

        /// <summary>
        /// Called after the view and its children has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();
            GenerateItems();
        }

        /// <summary>
        /// Called when the list of items has been changed.
        /// </summary>
        private void OnCollectionChanged(object sender, CollectionChangedEventArgs e)
        {
            Debug.Log("Collection changed");

            if (e.ChangeAction == CollectionChangeAction.Add)
            {
                GenerateItem(Items.GetItem(e.Id));
            }

            //// update list of items
            //if (e.ListChangeAction == ListChangeAction.Clear)
            //{
            //    UpdateItems();
            //}
            //else if (e.ListChangeAction == ListChangeAction.Add || e.ListChangeAction == ListChangeAction.DynamicAdd || e.ListChangeAction == ListChangeAction.DynamicAddSuppressLayoutChanged ||
            //    e.ListChangeAction == ListChangeAction.AddWithoutUpdatingUpdate)
            //{
            //    UpdateItems();
            //}
            //else if (e.ListChangeAction == ListChangeAction.Remove)
            //{
            //    UpdateItems();
            //}
            //else if (e.ListChangeAction == ListChangeAction.Replace)
            //{
            //    _updateVirtualization = true;
            //}
            //else if (e.ListChangeAction == ListChangeAction.ScrollTo)
            //{
            //    ScrollTo(e.StartIndex, e.Alignment);
            //}
            //else if (e.ListChangeAction == ListChangeAction.Modify)
            //{
            //    ItemsModified(e.StartIndex, e.EndIndex, e.FieldPath);
            //}
            //else if (e.ListChangeAction == ListChangeAction.Select)
            //{
            //    SelectItem(e.StartIndex);
            //}
            //else if (e.ListChangeAction == ListChangeAction.Move)
            //{
            //    _updateVirtualization = true;
            //}

            //if (ListChanged.HasEntries)
            //{
            //    ListChanged.Trigger(new ListChangedActionData { ListChangeAction = e.ListChangeAction, StartIndex = e.StartIndex, EndIndex = e.EndIndex, FieldPath = e.FieldPath });
            //}
        }

        #endregion
    }
}
