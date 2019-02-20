﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Xml.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using Delight.Editor;
using UnityEngine;
using System.Xml.Serialization;
using ProtoBuf;
#endregion

namespace Delight.Editor.Parser
{
    /// <summary>
    /// Contains configuration information.
    /// </summary>
    [ProtoContract]
    public class MasterConfig
    {
        #region Fields

        public static string ConfigFile = "DelightConfig.bin";

        [ProtoMember(1)]
        public string Name;

        [ProtoMember(2)]
        public BuildConfiguration BuildConfiguration;

        [ProtoMember(3)]
        public List<string> ContentFolders;

        [ProtoMember(4)]
        public List<string> Views;

        [ProtoMember(5)]
        public bool AssetsNeedBuild;

        private static MasterConfig _config;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MasterConfig()
        {
            ContentFolders = new List<string>();
            Views = new List<string>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets singleton instance of the config.
        /// </summary>
        public static MasterConfig GetInstance()
        {
            if (_config != null)
                return _config;

            LoadConfig();
            return _config;
        }

        /// <summary>
        /// Creates a default configuration object.
        /// </summary>
        public static MasterConfig CreateDefault()
        {
            var defaultConfig = new MasterConfig();
            defaultConfig.ContentFolders.Add("Assets/Content/");
            defaultConfig.ContentFolders.Add("Assets/Delight/Content/");
            return defaultConfig;
        }

        /// <summary>
        /// Loads config.
        /// </summary>
        private static void LoadConfig()
        {
            // check if file exist
            var configFilePath = GetConfigFilePath();
            if (!File.Exists(configFilePath))
            {
                _config = CreateDefault();
                return;
            }

            // deserialize file
            using (var file = File.OpenRead(configFilePath))
            {
                Debug.Log("Deserializing " + configFilePath);
                try
                {
                    _config = Serializer.Deserialize<MasterConfig>(file);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    Debug.LogError(String.Format("[Delight] Failed to deserialize config file \"{0}\". Creating new config.", ConfigFile));
                    _config = CreateDefault();
                    return;
                }
            }
        }

        /// <summary>
        /// Saves config.
        /// </summary>
        public void SaveConfig()
        {
            var configFilePath = GetConfigFilePath();
            Sanitize();

            using (var file = File.Open(configFilePath, FileMode.Create))
            {
                Debug.Log("Serializing " + configFilePath);
                Serializer.Serialize(file, _config);
            }
        }

        /// <summary>
        /// Gets config file path.
        /// </summary>
        private static string GetConfigFilePath()
        {
            // get application path minus "/Assets" folder
            var path = Application.dataPath.Substring(0, Application.dataPath.Length - 7);
            return String.Format("{0}/{1}", path, ConfigFile);
        }

        /// <summary>
        /// Sanitize configuration.
        /// </summary>
        public void Sanitize()
        {
            var invalidPathChars = Path.GetInvalidPathChars();

            // make sure paths are consistantly formatted
            for (int i = ContentFolders.Count - 1; i >= 0; --i)
            {
                var path = ContentFolders[i];
                if (String.IsNullOrEmpty(path) || path.IndexOfAny(invalidPathChars) >= 0)
                {
                    Debug.LogWarning(String.Format("[Delight] Improperly formatted content folder path \"{0}\" removed from configuration.", path));
                    ContentFolders.RemoveAt(i);
                    continue;
                }

                // make sure directory separators are uniform
                path = GetFormattedPath(path);

                // make sure path ends with a directory separator
                if (!path.EndsWith("/"))
                {
                    path += "/";
                }

                ContentFolders[i] = path;
            }
        }

        /// <summary>
        /// Gets uniformally formatted path with forward slashes "/" as directory separators.
        /// </summary>
        public static string GetFormattedPath(string path)
        {
            if (String.IsNullOrEmpty(path))
                return path;
            return path.Replace("\\", "/");
        }

        #endregion
    }

    public enum BuildConfiguration
    {
        Dev = 0,
        Staging = 1,
        Production = 2
    }
}

