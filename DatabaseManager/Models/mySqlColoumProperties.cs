using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseManager.Models
{
    public class mySqlColoumProperties
    {
        public string Name;
        public bool isForeignkey;
        public bool isKey;
        public MysqlDataTypes ColType;
        //has only to be Set for VarcharTypes
        public int MaxLength=-1;
        public int AutoIncrementStartValue=1;
        public int AutoIncrementValue = 1;
        public bool AllowDBNull;
    }
}
