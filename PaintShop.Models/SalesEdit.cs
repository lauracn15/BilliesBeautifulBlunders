namespace PaintShop.Models
{
    public class SalesEdit
    {
        public int CartId { get; set; }
        public int SalesId { get; set; }
        public override string ToString() => $"[{CartId}] {CartId}";
    }
}
