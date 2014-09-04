using System.Globalization;

namespace Corporate.Expenditures.ViewModels
{
    public class TotalsCellViewModel
    {
        public int OfficeId { get; set; }
        public int ExpenseId { get; set; }
        public string Text { get; set; }
        public bool IsEnabled { 
            get { return OfficeId != 0 && ExpenseId != 0 && Text != "0"; } 
        }

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
