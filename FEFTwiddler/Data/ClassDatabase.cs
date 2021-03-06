﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FEFTwiddler.Extensions;

namespace FEFTwiddler.Data
{
    public class ClassDatabase : BaseDatabase
    {
        public ClassDatabase(Enums.Language language) : base(language)
        {
            _data = XElement.Parse(Properties.Resources.Data_Classes);
        }

        public Class GetByID(Enums.Class classId)
        {
            var row = _data
                .Elements("class")
                .Where((x) => x.Attribute("id").Value == ((byte)classId).ToString())
                .First();

            return FromElement(row);
        }

        public IEnumerable<Class> GetAll()
        {
            var elements = _data.Elements("class");
            var rows = new List<Class>();
            foreach (var e in elements)
            {
                rows.Add(FromElement(e));
            }
            return rows;
        }

        private Class FromElement(XElement row)
        {
            var displayName = GetDisplayName(row);
            var baseStats = row.Elements("baseStats").First();
            var maxStats = row.Elements("maxStats").First();

            return new Class
            {
                ClassID = (Enums.Class)row.GetAttribute<byte>("id"),
                DisplayName = displayName,
                BaseStats = new Model.Stat()
                {
                    HP = baseStats.GetAttribute<sbyte>("hp"),
                    Str = baseStats.GetAttribute<sbyte>("str"),
                    Mag = baseStats.GetAttribute<sbyte>("mag"),
                    Skl = baseStats.GetAttribute<sbyte>("skl"),
                    Spd = baseStats.GetAttribute<sbyte>("spd"),
                    Lck = baseStats.GetAttribute<sbyte>("lck"),
                    Def = baseStats.GetAttribute<sbyte>("def"),
                    Res = baseStats.GetAttribute<sbyte>("res")
                },
                MaximumStats = new Model.Stat()
                {
                    HP = maxStats.GetAttribute<sbyte>("hp"),
                    Str = maxStats.GetAttribute<sbyte>("str"),
                    Mag = maxStats.GetAttribute<sbyte>("mag"),
                    Skl = maxStats.GetAttribute<sbyte>("skl"),
                    Spd = maxStats.GetAttribute<sbyte>("spd"),
                    Lck = maxStats.GetAttribute<sbyte>("lck"),
                    Def = maxStats.GetAttribute<sbyte>("def"),
                    Res = maxStats.GetAttribute<sbyte>("res")
                }
            };
        }
    }
}
