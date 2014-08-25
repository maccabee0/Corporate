using System.Globalization;

namespace Corporate.Expenditures.ViewModels
{
    public class TotalsCellViewModel
    {
        public int OfficeId { get; set; }
        public int ExpenseId { get; set; }
        public string Text { get; set; }

        public TotalsCellViewModel(int officeId, int expenseId, string text)
        {
            OfficeId = officeId;
            ExpenseId = expenseId;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
