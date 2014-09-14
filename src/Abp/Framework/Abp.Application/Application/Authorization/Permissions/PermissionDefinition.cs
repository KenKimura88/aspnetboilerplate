﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Abp.Localization;

namespace Abp.Application.Authorization.Permissions
{
    /// <summary>
    /// Represents a permission.
    /// A permission is used to restrict functionalities of the application from unauthorized users.
    /// </summary>
    public class PermissionDefinition
    {
        /// <summary>
        /// Parent of this permission if one exists.
        /// If set, this permission can be granted only if parent is granted.
        /// </summary>
        public PermissionDefinition Parent { get; private set; }

        /// <summary>
        /// Unique name of the permission.
        /// This is the key name to grant permissions.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Display name of the permission.
        /// This can be used to show permission to the user.
        /// </summary>
        public LocalizableString DisplayName { get; private set; }

        /// <summary>
        /// A brief description for this permission.
        /// </summary>
        public LocalizableString Description { get; private set; }

        /// <summary>
        /// Is this permission granted by default.
        /// Default value: false.
        /// </summary>
        public bool IsGrantedByDefault { get; private set; }

        /// <summary>
        /// List of child permissions. A child permission can be granted only if parent is granted.
        /// </summary>
        public IReadOnlyList<PermissionDefinition> Children
        {
            get { return _children.ToImmutableList(); }
        }
        private readonly List<PermissionDefinition> _children;

        /// <summary>
        /// Creates a new Permission.
        /// </summary>
        /// <param name="name">Unique name of the permission</param>
        /// <param name="displayName">Display name of the permission</param>
        /// <param name="isGrantedByDefault">Is this permission granted by default. Default value: false.</param>
        /// <param name="description">A brief description for this permission</param>
        internal PermissionDefinition(string name, LocalizableString displayName, bool isGrantedByDefault = false, LocalizableString description = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (displayName == null)
            {
                throw new ArgumentNullException("displayName");
            }

            Name = name;
            DisplayName = displayName;
            IsGrantedByDefault = isGrantedByDefault;
            Description = description;

            _children = new List<PermissionDefinition>();
        }

        /// <summary>
        /// Adds a child permission.
        /// A child permission can be granted only if parent is granted.
        /// </summary>
        /// <returns>Returns new child permission</returns>
        public PermissionDefinition CreateChildPermission(string name, LocalizableString displayName, bool isGrantedByDefault = false, LocalizableString description = null)
        {
            var permission = new PermissionDefinition(name, displayName, isGrantedByDefault, description) { Parent = this };
            _children.Add(permission);
            return permission;
        }
    }
}
