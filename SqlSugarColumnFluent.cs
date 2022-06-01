namespace SqlSugar.Extra
{
    public class SqlSugarColumnFluent
    {
        internal SugarColumn SugarColumn { get; } = new SugarColumn();


        internal SqlSugarColumnFluent()
        {
        }

        public SqlSugarColumnFluent IndexGroupNameList(string[] val)
        {
            SugarColumn.IndexGroupNameList = val;
            return this;
        }

        public SqlSugarColumnFluent DefaultValue(string val)
        {
            SugarColumn.DefaultValue = val;
            return this;
        }

        public SqlSugarColumnFluent IsJson(bool val = true)
        {
            SugarColumn.IsJson = val;
            return this;
        }

        public SqlSugarColumnFluent SerializeDateTimeFormat(string val)
        {
            SugarColumn.SerializeDateTimeFormat = val;
            return this;
        }

        public SqlSugarColumnFluent NoSerialize(bool val = true)
        {
            SugarColumn.NoSerialize = val;
            return this;
        }

        public SqlSugarColumnFluent IsTranscoding(bool val = true)
        {
            SugarColumn.IsTranscoding = val;
            return this;
        }

        public SqlSugarColumnFluent IsEnableUpdateVersionValidation(bool val = true)
        {
            SugarColumn.IsEnableUpdateVersionValidation = val;
            return this;
        }

        public SqlSugarColumnFluent IsOnlyIgnoreUpdate(bool val = true)
        {
            SugarColumn.IsOnlyIgnoreUpdate = val;
            return this;
        }

        public SqlSugarColumnFluent IsOnlyIgnoreInsert(bool val = true)
        {
            SugarColumn.IsOnlyIgnoreInsert = val;
            return this;
        }

        public SqlSugarColumnFluent OracleSequenceName(string val)
        {
            SugarColumn.OracleSequenceName = val;
            return this;
        }

        public SqlSugarColumnFluent DecimalDigits(int val)
        {
            SugarColumn.DecimalDigits = val;
            return this;
        }

        public SqlSugarColumnFluent ColumnDataType(string val)
        {
            SugarColumn.ColumnDataType = val;
            return this;
        }

        public SqlSugarColumnFluent OldColumnName(string val)
        {
            SugarColumn.OldColumnName = val;
            return this;
        }

        public SqlSugarColumnFluent IsNullable(bool val = true)
        {
            SugarColumn.IsNullable = val;
            return this;
        }

        public SqlSugarColumnFluent Length(int val)
        {
            SugarColumn.Length = val;
            return this;
        }

        public SqlSugarColumnFluent ColumnDescription(string val)
        {
            SugarColumn.ColumnDescription = val;
            return this;
        }

        public SqlSugarColumnFluent MappingKeys(string val)
        {
            SugarColumn.MappingKeys = val;
            return this;
        }

        public SqlSugarColumnFluent IsIdentity(bool val = true)
        {
            SugarColumn.IsIdentity = val;
            return this;
        }

        public SqlSugarColumnFluent IsPrimaryKey(bool val = true)
        {
            SugarColumn.IsPrimaryKey = val;
            return this;
        }

        public SqlSugarColumnFluent IsIgnore(bool val = true)
        {
            SugarColumn.IsIgnore = val;
            return this;
        }

        public SqlSugarColumnFluent ColumnName(string val)
        {
            SugarColumn.ColumnName = val;
            return this;
        }

        public SqlSugarColumnFluent UniqueGroupNameList(string[] val)
        {
            SugarColumn.UniqueGroupNameList = val;
            return this;
        }

        public SqlSugarColumnFluent IsArray(bool val = true)
        {
            SugarColumn.IsArray = val;
            return this;
        }
    }
}
