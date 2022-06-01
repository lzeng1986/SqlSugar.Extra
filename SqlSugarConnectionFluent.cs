using System;
using System.Collections.Generic;
using System.Reflection;

namespace SqlSugar.Extra
{
    public class SqlSugarConnectionFluent
    {
        private class EntityFluent
        {
            public SugarTable SugarTable;

            public Dictionary<PropertyInfo, SugarColumn> Columns;
        }

        private Dictionary<Type, EntityFluent> tables = new Dictionary<Type, EntityFluent>();

        internal SqlSugarConnectionFluent(ConnectionConfig config)
        {
            config.ConfigureExternalServices.EntityNameService = EntityNameService;
            config.ConfigureExternalServices.EntityService = EntityService;
            void EntityNameService(Type type, EntityInfo info)
            {
                if (tables.TryGetValue(type, out var value3))
                {
                    info.DbTableName = value3.SugarTable.TableName;
                    info.IsDisabledDelete = value3.SugarTable.IsDisabledDelete;
                    info.IsDisabledUpdateAll = value3.SugarTable.IsDisabledUpdateAll;
                    info.TableDescription = value3.SugarTable.TableDescription;
                }
            }
            void EntityService(PropertyInfo propertyInfo, EntityColumnInfo info)
            {
                if (tables.TryGetValue(propertyInfo.ReflectedType, out var value) && value.Columns.TryGetValue(propertyInfo, out var value2))
                {
                    info.IndexGroupNameList = value2.IndexGroupNameList;
                    info.DefaultValue = value2.DefaultValue;
                    info.IsJson = value2.IsJson;
                    info.SerializeDateTimeFormat = value2.SerializeDateTimeFormat;
                    info.NoSerialize = value2.NoSerialize;
                    info.IsTranscoding = value2.IsTranscoding;
                    info.IsEnableUpdateVersionValidation = value2.IsEnableUpdateVersionValidation;
                    info.IsOnlyIgnoreUpdate = value2.IsOnlyIgnoreUpdate;
                    info.IsOnlyIgnoreInsert = value2.IsOnlyIgnoreInsert;
                    info.OracleSequenceName = value2.OracleSequenceName;
                    info.DecimalDigits = value2.DecimalDigits;
                    info.DataType = value2.ColumnDataType;
                    info.OldDbColumnName = value2.OldColumnName;
                    info.IsNullable = value2.IsNullable;
                    info.Length = value2.Length;
                    info.ColumnDescription = value2.ColumnDescription;
                    info.IsIdentity = value2.IsIdentity;
                    info.IsPrimarykey = value2.IsPrimaryKey;
                    info.IsIgnore = value2.IsIgnore;
                    info.DbColumnName = value2.ColumnName;
                    info.UIndexGroupNameList = value2.UniqueGroupNameList;
                    info.IsArray = value2.IsArray;
                }
            }
        }

        public SqlSugarConnectionFluent Entity<T>(Action<SqlSugarEntityFluent<T>> action)
        {
            SqlSugarEntityFluent<T> sqlSugarEntityFluent = new SqlSugarEntityFluent<T>();
            action(sqlSugarEntityFluent);
            tables[typeof(T)] = new EntityFluent
            {
                SugarTable = sqlSugarEntityFluent.SugarTable,
                Columns = sqlSugarEntityFluent.Columns
            };
            return this;
        }
    }
}
