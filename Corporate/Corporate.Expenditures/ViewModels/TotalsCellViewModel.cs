using System.Globalization;

namespace Corporate.Expenditures.ViewModels
{
    public class TotalsCellViewModel
    {
        public int OfficeId { get; set; }
        public int ExpenseId { get; set; }
        public decimal Total { get; set; }

        public TotalsCellViewModel(int officeId, int expenseId, decimal total)
        {
            OfficeId = officeId;
            ExpenseId = expenseId;
            Total = total;
        }

        public override string ToString()
        {
            return Total == 0 ? "" : Total.ToString(CultureInfo.InvariantCulture);
        }
    }
}
