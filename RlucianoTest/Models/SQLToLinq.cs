using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AbsenceTest.Models
{
    public  class ConverTable
    {
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (System.Reflection.PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            PropertyInfo[] propertyInfoArray;
            int i;
            object value;
            DataTable dataTable = new DataTable();
            PropertyInfo[] properties = null;
            if (varlist == null)
            {
                return dataTable;
            }
            foreach (T t in varlist)
            {
                if (properties == null)
                {
                    properties = t.GetType().GetProperties();
                    propertyInfoArray = properties;
                    for (i = 0; i < (int)propertyInfoArray.Length; i++)
                    {
                        PropertyInfo propertyInfo = propertyInfoArray[i];
                        System.Type propertyType = propertyInfo.PropertyType;
                        if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            propertyType = propertyType.GetGenericArguments()[0];
                        }
                        dataTable.Columns.Add(new DataColumn(propertyInfo.Name, propertyType));
                    }
                }
                DataRow dataRow = dataTable.NewRow();
                propertyInfoArray = properties;
                for (i = 0; i < (int)propertyInfoArray.Length; i++)
                {
                    PropertyInfo propertyInfo1 = propertyInfoArray[i];
                    DataRow dataRow1 = dataRow;
                    string name = propertyInfo1.Name;
                    if (propertyInfo1.GetValue(t, null) == null)
                    {
                        value = DBNull.Value;
                    }
                    else
                    {
                        value = propertyInfo1.GetValue(t, null);
                    }
                    dataRow1[name] = value;
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
    }
}