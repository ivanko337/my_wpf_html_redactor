namespace HTMLEditor.Core
{
    public class ComboBoxItem
    {
        public ComboBoxItem()
        { }

        public ComboBoxItem(string id, string value)
        {
            this.Value = value;
            this.Id = id;
        }
        public string Id { get; set; }
        public string Value { get; set; }
    }
}
