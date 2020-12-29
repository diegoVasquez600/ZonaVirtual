namespace ZonaClient.Models
{
    public class CmbModel
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
