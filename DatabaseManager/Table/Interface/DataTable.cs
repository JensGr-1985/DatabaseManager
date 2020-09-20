using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DatabaseManager.Table.Interface
{
    interface IDataTable
    {

        
        /// <summary>
        /// Return a SQL Statement for Createing a DataTable with added ID field cabale of store <typeparamref name="T"/> types
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public string CreateTable<T>(string tablename);

        /// <summary>
        /// Return a SQL Statement for Createing a DataTable with added ID field cabale of storing <typeparamref name="T"/> types
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public string CreateTable(string tablename, IEnumerable<Tuple<string, SqlDbType>> coloums);

        /// <summary>
        /// is used to update a Value in System
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="id"></param>
        /// <param name="coloumsValues"></param>
        /// <returns></returns>
        public string UpdateValuesinTable(string tablename,int id, IEnumerable<Tuple<string, SqlDbType, object>> coloumsValues);

        /// <summary>
        /// Deletes The id Value in Table
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteValuesinTable(string tablename, int id);
        
        
        
    }
}
