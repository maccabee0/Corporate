using System;
using System.Collections;
using System.Collections.Generic;

namespace Corporate.Expenditures.DataMatrix
{
    public class DataMatrix : IDataMatrix
    {
        public List<MatrixColumn> Columns { get; set; }
        public Dictionary<string, Dictionary<string, object>> Rows { get; set; }

        public DataMatrix()
        {
            Columns = new List<MatrixColumn>();
            Rows = new Dictionary<string, Dictionary<string, object>>();
        }

        public IEnumerator GetEnumerator()
        {
            return Rows.Values.GetEnumerator();
        }
    }
}
