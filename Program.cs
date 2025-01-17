Product store = new Product();
store.Register("Chair", 1000, 12, "Home", true);

System.Console.Write("Enter discount amount: ");
string price = store.SetDiscount(int.Parse(System.Console.ReadLine()) );
System.Console.WriteLine(price);

System.Console.WriteLine();
System.Console.Write("Enter how many items arrived: ");
string amount = store.AddNewItems(int.Parse(System.Console.ReadLine()) );
System.Console.WriteLine(amount);

System.Console.WriteLine();
System.Console.Write("Enter how many pieces you want to buy: ");
string sell = store.SellItem(int.Parse(System.Console.ReadLine()) );
System.Console.WriteLine(sell);

System.Console.WriteLine();
string leftInStock = store.CheckAvailability();
System.Console.WriteLine(leftInStock);

System.Console.WriteLine();
string sum = store.GetPriceTag();
System.Console.WriteLine(sum);

class Product{
    private string? Name;
    private decimal Price;
    private int StockQuantity;
    private string? Category;
    private bool IsDiscounted;
    private int discount;

    public string Register(string Name, decimal Price, int StockQuantity, string Category, bool IsDiscounted) {
        this.Name = Name;
        this.Price = Price;
        this.StockQuantity = StockQuantity;
        this.Category = Category;
        this.IsDiscounted = IsDiscounted;
        this.discount = 0;
        return $"Registration is successful";
    }

    public string SetDiscount(int discountPercent){
        if (discountPercent>=100){
            return "Invalid discount";
        }
        else{
            if(this.IsDiscounted){
                this.discount = discountPercent;
                decimal discountMultiplier = 1 - discountPercent / 100m;
                decimal discountedPrice = this.Price * discountMultiplier;
                return $"New price: {discountedPrice} rubles";
            }
            else{
                return "This product doesn't have a discount.";
            }
        }
    }

    public string AddNewItems(int count){
        if (count>=0){
            StockQuantity = StockQuantity+count;
            return $"Now in stock: {StockQuantity} pieces";
        }
        else{
            return "Delivery error";
        }
    }

    public string SellItem(int count){
        if (StockQuantity>=count){
            StockQuantity = StockQuantity-count;
            return $"Sold! Cost: {Price*count} rubles";
        }
        else{
            return "Not enough items in stock";
        }
    }

    public string CheckAvailability(){
        if (StockQuantity>20){
            return "Lots of items";
        }
        else if (StockQuantity>=5 && StockQuantity<=20){
            return "Sufficient items";
        }
        else{
            System.Console.WriteLine("Urgent delivery needed!");
            return "Sufficient items (15 pcs)";
        }
    }

    public string GetPriceTag(){
        if(this.IsDiscounted){
            decimal Multiplier = 1-discount/100m;
            decimal discountedPrice = this.Price*Multiplier;
            return $"{this.Name}, Old price: {this.Price} rub, New price: {discountedPrice} rub (Discount!)";
        }
        else{
            return $"{this.Name}, Price: {this.Price} rub";
        }
    }
}