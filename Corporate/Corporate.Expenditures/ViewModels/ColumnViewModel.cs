namespace Corporate.Expenditures.ViewModels
{
    public class ColumnViewModel
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public ColumnViewModel(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return "ColumnViewModel: " + Name;
        }
    }
}
