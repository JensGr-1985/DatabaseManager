using DatabaseManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseManager.Table
{
    class DataTable
    {
    }


    public static string CreateTABLE(string tableName, IEnumerable<mySqlColoumProperties> mySqlColoums)
    {
        string sqlsc;
        sqlsc = "CREATE TABLE " + tableName + "(";
        foreach(var col in mySqlColoums)
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
                case MysqlDataTypes.VARCHAR:
                default:
                    sqlsc += string.Format(" varchar({0}) ", col.MaxLength == -1 ? "max" : col.MaxLength.ToString());
                    break;
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
