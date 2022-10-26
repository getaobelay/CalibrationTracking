// Author     : Gilles Macabies
// Solution   : DataGridFilter
// Projet     : DataGridFilter
// File       : Loc.cs
// Created    : 18/12/2019

using System;
using System.Collections.Generic;
using System.Globalization;
using CalibrationTracking.CustomeControls.TableControl;

// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable UnusedType.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CheckNamespace

namespace CalibrationTracking.CustomeControls.TableControl
{
    public enum Local
    {
        English = 0,
        Hebrew
    }

    public class Loc
    {
        #region Private Fields

        private int language;

        // culture name(used for dates)
        private static readonly string[] CultureNames = { "en-US", "he-IL" };

        // RESPECT THE ORDER OF THE Local ENUMERATION
        // translation
        private static readonly Dictionary<string, string[]> Translation = new Dictionary<string, string[]>
        {
            {
                "All", new[]
                {
                    "(Select all)",
                    "(בחר הכול)",
                }
            },
            {
                "Empty", new[]
                {
                    "(Blank)",
                    "(ריק)",
                }
            },
            {
                "Clear", new[]
                {
                    "Clear filter \"{0}\"",
                    "נקה את הפילטר \"{0}\"",
                }
            },
            {
                "Search", new[]
                {
                    "Search (contains)",
                    "חיפוש (מכיל)",
                }
            },
            {
                "Ok", new[]
                {
                    "Ok",
                    "אישור"
                }
            },
            {
                "Cancel", new[]
                {
                    "Cancel",
                    "ביטול",
                }
            },
            {
                "Status", new[]
                {
                    "{0:n0} record(s) found on {1:n0}",
                    "נמצאו {0:n0} רשומות",
                }
            },
            {
                "ElapsedTime", new[]
                {
                    "Elapsed time {0:mm}:{0:ss}.{0:ff}",
                    "זמן ריענון {0:mm}:{0:ss}.{0:ff}",
                }
            }
        };

        #endregion Private Fields

        #region Constructors

        public Loc()
        {
            Language = (int)Local.Hebrew;
        }

        #endregion Constructors

        #region Public Properties

        public string All => Translation["All"][Language];

        public string Cancel => Translation["Cancel"][Language];

        public string Clear => Translation["Clear"][Language];

        public CultureInfo Culture { get; set; }

        public string CultureName => CultureNames[Language];

        public string ElapsedTime => Translation["ElapsedTime"][Language];

        public string Empty => Translation["Empty"][Language];

        public int Language
        {
            get => language;
            set
            {
                language = value;
                Culture = new CultureInfo(CultureNames[Language]);
            }
        }

        public string LanguageName => Enum.GetName(typeof(Local), Language);
        public string Ok => Translation["Ok"][Language];
        public string Search => Translation["Search"][Language];
        public string Status => Translation["Status"][Language];

        #endregion Public Properties
    }
}
