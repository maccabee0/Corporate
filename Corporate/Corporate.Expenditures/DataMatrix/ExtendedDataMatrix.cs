using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corporate.Expenditures.ViewModels;

namespace Corporate.Expenditures.DataMatrix
{
    public class ExtendedDataMatrix : IDataMatrix
    {
        public IEnumerator GetEnumerator()
        {
            return Rows.Values.GetEnumerator();
        }

        public ExtendedDataMatrix()
        {
            Columns = new List<MatrixColumn>();
            Rows = new Dictionary<string, Dictionary<string, TotalsCellViewModel>>();
        }

        public List<MatrixColumn> Columns { get; set; }
        public Dictionary<string, Dictionary<string, TotalsCellViewModel>> Rows { get; set; }
    }
}
