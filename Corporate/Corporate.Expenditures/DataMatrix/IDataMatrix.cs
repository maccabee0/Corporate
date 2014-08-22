using System.Collections;
using System.Collections.Generic;

namespace Corporate.Expenditures.DataMatrix
{
    public interface IDataMatrix : IEnumerable
    {
        List<MatrixColumn> Columns { get; set; }
    }
}
