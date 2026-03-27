namespace BookstoreApp.Models;

public class Cart
{
    public List<CartLine> Lines { get; set; } = new List<CartLine>();

    public virtual void AddItem(Book book, int quantity)
    {
        CartLine? line = Lines.Where(b => b.Book.BookID == book.BookID).FirstOrDefault();

        if (line == null)
        {
            Lines.Add(new CartLine { Book = book, Quantity = quantity });
        }
        else
        {
            line.Quantity += quantity;
        }
    }

    public virtual void RemoveLine(Book book) =>
        Lines.RemoveAll(l => l.Book.BookID == book.BookID);

    public decimal CalculateTotal() =>
        (decimal)Lines.Sum(e => e.Book.Price * e.Quantity);

    public virtual void Clear() => Lines.Clear();
}

public class CartLine
{
    public int CartLineID { get; set; }
    public required Book Book { get; set; }
    public int Quantity { get; set; }
}