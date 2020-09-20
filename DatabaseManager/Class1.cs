using System;
using System.Collections.Generic;
using DatabaseManager.Models;
namespace DatabaseManager
{
    public class Class1
    {
        public Class1(string _tablename,IEnumerable<MySqlColoumProperties> _sqlColoumns)
        {
            
        }

        public Class1(string _tablename, IEnumerable<SqlColoumProperties> _sqlColoumns)
        {

        }

        private string CreateTABLEMySQL(string tableName, IEnumerable<MySqlColoumProperties> mySqlColoums)
        {
            string sqlsc;
            sqlsc = "CREATE TABLE " + tableName + "(";
            foreach (var col in mySqlColoums)
            {
                sqlsc += "\n [" + col.Name + "] ";

                switch (col.ColType)
                {
                    case MysqlDataTypes.INT:
                        sqlsc += " int ";
                        break;
                    case MysqlDataTypes.BIGINT:
                        sqlsc += " bigint ";
                        break;
                    case MysqlDataTypes.MEDIUMINT:
                        sqlsc += " smallint";
                        break;
                    case MysqlDataTypes.TINYINT:
                        sqlsc += " tinyint";
                        break;
                    case MysqlDataTypes.DECIMAL:
                        sqlsc += " decimal ";
                        break;
                    case MysqlDataTypes.DATETIME:
                        sqlsc += " datetime ";
                        break;
                    case MysqlDataTypes.DATE:
                        sqlsc += " date ";
                        break;
                    case MysqlDataTypes.TIME:
                        sqlsc += " time ";
                        break;
                    case MysqlDataTypes.TIMESTAMP:
                        sqlsc += " Timestamp ";
                        break;
                    case MysqlDataTypes.BOOLEAN:
                        sqlsc += " boolean ";
                        break;

                    case MysqlDataTypes.BLOB:
                        sqlsc += " Blob ";
                        break;
                    case MysqlDataTypes.TEXT:
                        sqlsc += " Text ";
                        break;

                    case MysqlDataTypes.VARCHAR:
                        sqlsc += string.Format(" varchar({0}) ", col.MaxLength == -1 ? "max" : col.MaxLength.ToString());
                        break;
                    default:
                        throw new InvalidOperationException($"{Enum.GetName(typeof(SqlColoumProperties),col.ColType)} is not implemented yet");
                        
                }
                if (col.isKey)
                    sqlsc += " IDENTITY(" + col.AutoIncrementStartValue + "," + col.AutoIncrementValue + ") ";
                if (!col.AllowDBNull)
                    sqlsc += " NOT NULL ";
                sqlsc += ",";
            }
            return sqlsc.Substring(0, sqlsc.Length - 1) + "\n)";
        }

        private string CreateTABLESQL(string tableName, IEnumerable<SqlColoumProperties> SqlColoums)
        {
            string sqlsc;
            sqlsc = "CREATE TABLE " + tableName + "(";
            foreach (var col in SqlColoums)
            {
                sqlsc += "\n [" + col.Name + "] ";

                switch (col.ColType)
                {
                    case SqlDataTypes.INT:
                        sqlsc += " int ";
                        break;
                    case SqlDataTypes.BIGINT:
                        sqlsc += " bigint ";
                        break;
                    case SqlDataTypes.SMALLINT:
                        sqlsc += " smallint";
                        break;
                    case SqlDataTypes.TINYINT:
                        sqlsc += " tinyint";
                        break;
                    case SqlDataTypes.DECIMAL:
                        sqlsc += " decimal ";
                        break;
                    case SqlDataTypes.DATETIME:
                        sqlsc += " datetime ";
                        break;
                    case SqlDataTypes.UNIQUEIDENTIFIER:
                        sqlsc += " uniqueidentifier ";
                        break;
                    case SqlDataTypes.FLOAT:
                        sqlsc += " flaot ";
                        break;
                    case SqlDataTypes.TIMESTAMP:
                        sqlsc += " Timestamp ";
                        break;
                    case SqlDataTypes.MONEY:
                        sqlsc += " MONEY ";
                        break;

                    case SqlDataTypes.BIT:
                        sqlsc += " bit ";
                        break;
                    case SqlDataTypes.TEXT:
                        sqlsc += " Text ";
                        break;

                    case SqlDataTypes.VARCHAR:
                        sqlsc += string.Format(" varchar({0}) ", col.MaxLength == -1 ? "max" : col.MaxLength.ToString());
                        break;

                    case SqlDataTypes.VARBINARY:
                        sqlsc += string.Format(" VARBINARY({0}) ", col.MaxLength == -1 ? "max" : col.MaxLength.ToString());
                        break;
                    default:
                        throw new InvalidOperationException($"{Enum.GetName(typeof(SqlColoumProperties), col.ColType)} is not implemented yet");

                }
                if (col.isKey)
                    sqlsc += " IDENTITY(" + col.AutoIncrementStartValue + "," + col.AutoIncrementValue + ") ";
                if (!col.AllowDBNull)
                    sqlsc += " NOT NULL ";
                sqlsc += ",";
            }
            return sqlsc.Substring(0, sqlsc.Length - 1) + "\n)";
        }
    }
}
