using System;
using System.Collections.Generic;

class Product
{
    public static string brand = "ABC";  // common for all products
    public static Dictionary<string, Product> products = new Dictionary<string, Product>();

    public string pcode;
    public string pname;
    public int qty_in_stock;
    public int discount_allowed;
    public int price;

    public static void TakeInputsFromAdmin()
    {
        Console.Write("Enter Pcode: ");
        string pcode = Console.ReadLine();

        Console.Write("Enter Pname: ");
        string pname = Console.ReadLine();

        Console.Write("Enter Qty_In_Stock: ");
        int qty_in_stock = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Discount_Allowed : ");
        int discount_allowed = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Price: ");
        int price = Convert.ToInt32(Console.ReadLine());
        AddProduct(pcode, pname, qty_in_stock, discount_allowed, price);
    }

    public Product(string pcode, string pname, int qty_in_stock, int discount_allowed, int price)
    {
        this.pcode = pcode;
        this.pname = pname;
        this.qty_in_stock = qty_in_stock;
        this.discount_allowed = discount_allowed;
        this.price = price;
    }

    public static void AddProduct(string pcode, string pname, int qty_in_stock, int discount_allowed, int price)
    {
        if (products.ContainsKey(pcode))
        {
            Console.WriteLine($"Product with pcode {pcode} already exists.");
        }
        else
        {
            products[pname] = new Product(pcode, pname, qty_in_stock, discount_allowed, price);
            Console.WriteLine($"Product with pcode {pcode} added successfully.");
        }
    }

    public static void DisplayProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products found.");
        }
        else
        {
            Console.WriteLine("Product details:");
            foreach (KeyValuePair<string, Product> product in products)
            {
                Console.WriteLine($"pname: {product.Key}, pcode: {product.Value.pcode}, qty_in_stock: {product.Value.qty_in_stock}, discount_allowed: {product.Value.discount_allowed}, price:{product.Value.price}");
            }
        }
    }
    public static int OrderProduct()
    {
        Console.Write("Enter Pname: ");
        string pname = Console.ReadLine();
        int bill;

        if (products.ContainsKey(pname))
        {
            Console.WriteLine($"Product {pname} found");
            var firstDate = new DateTime(2023, 1, 26);
            bill = products[pname].price - products[pname].discount_allowed;

            if (DateTime.Now == firstDate)
            {

                return bill / 2;
            }
            else
            {
                return bill;
            }

        }
        else
        {
            Console.WriteLine($"Product {pname} not found.");
            return 0;
        }
    }



    static void Main(string[] args)
    {
        int i = 0;
        while (i < 5)
        {
            //admin
            Console.Write("Enter your choice: ");
            int choice1 = Convert.ToInt32(Console.ReadLine());
            if (choice1 == 1)
            {
                TakeInputsFromAdmin();
                DisplayProducts();
            }
            if (choice1 == 2)
            {

                //customer
                Console.WriteLine(OrderProduct());
                Console.WriteLine(OrderProduct());
            }
        }
        i++;
    }
}