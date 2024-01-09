using Inventory;

using Types;

string greeting = @"
+-------------------------------------------------------------+
|                                                             |
|               Welcome to Reductio & Absurdum                |
|  Providing high-quality magical goods for over 1000 years!  |
|                                                             |
+-------------------------------------------------------------+";

Console.WriteLine(greeting);

List<ProductType> productTypes = new()
{
    new ProductType()
    {
        Name = "apparel",
        ID = 1
    },
    new ProductType()
    {
        Name = "potions",
        ID = 2
    },
    new ProductType()
    {
        Name = "enchanted objects",
        ID = 3
    },
    new ProductType()
    {
        Name = "wands",
        ID = 4
    }
};

List<Product> products = new()
{
    new Product()
    {
        ProductID = 1,
        Name = "Tattered Robe",
        Price = 74.99M,
        Available = true,
        ProductTypeID = 1,
        DateStocked = new DateTime(1313, 10, 31)
    },
    new Product()
    {
        ProductID = 2,
        Name = "Goblin's Bane",
        Price = 4.99M,
        Available = true,
        ProductTypeID = 2,
        DateStocked = new DateTime(1438, 2, 14)
    },
    new Product()
    {
        ProductID = 3,
        Name = "Frank's Toe Knife",
        Price = 144.99M,
        Available = false,
        ProductTypeID = 3,
        DateStocked = new DateTime(2009, 12, 30)
    },
    new Product()
    {
        ProductID = 4,
        Name = "Weighted Branch",
        Price = 14.99M,
        Available = true,
        ProductTypeID = 4,
        DateStocked = new DateTime(1802, 4, 20)

    },
    new Product()
    {
        ProductID = 5,
        Name = "Mickey's Hat",
        Price = 24.99M,
        Available = true,
        ProductTypeID = 1,
        DateStocked = new DateTime(2016, 6, 7)
    },
    new Product()
    {
        ProductID = 6,
        Name = "Troll Breath",
        Price = 24.99M,
        Available = true,
        ProductTypeID = 2,
        DateStocked = new DateTime(2014, 10, 6)
    },
};

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"
Main Menu:

0. Exit
1. All Products
2. Add a Product
3. Update a Product
4. Delete a Product
5. View Product by Type
6. View Available Products");

    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        AddProduct();
    }
    else if (choice == "3")
    {
        UpdateProduct();
    }
    else if (choice == "4")
    {
        DeleteProduct();
    }
    else if (choice == "5")
    {
        //comment
    }
    else if (choice == "6")
    {
        //comment
    }
}

void ListProducts()
{
    decimal totalValue = 0.0m;
    foreach (Product product in products)
    {
        if (product.Available)
        {
            totalValue += product.Price;
        }
    }

    Console.WriteLine(@"
+-------------------------------------------------------------+
|                                                             |
|                         Products                            |
|                                                             |
+-------------------------------------------------------------+");

    foreach (Product product in products)
    {
        Console.WriteLine($@"
        {product.ProductID}. {product.Name}   
           Price: ${product.Price}   
           Available: {product.Available}   
           Days Available: {product.DaysAvailable}
           Type ID: {product.ProductTypeID}");
    }

    Console.WriteLine($"Total Inventory Value: ${totalValue}");
    Console.ReadLine();
}

void AddProduct()
{
    Console.WriteLine("Enter Product Name: ");
    string productName = Console.ReadLine();

    Console.WriteLine("\nEnter Product Price: ");
    decimal productPrice = Convert.ToDecimal(Console.ReadLine());

    Console.WriteLine("\nAvailable? (True)/(False)");
    bool productAvailability = Convert.ToBoolean(Console.ReadLine().ToLower().Trim());

    Console.WriteLine(@"
+-------------------------------------------------------------+
|                                                             |
|                       Product Types                         |
|                                                             |
+-------------------------------------------------------------+");
    foreach (var productType in productTypes)
    {
        Console.WriteLine($"{productType.ID}. {productType.Name}");
    }

    Console.WriteLine("Select a Product Type: ");
    int productTypeId = Convert.ToInt32(Console.ReadLine());

    Product newProduct = new()
    {
        Name = productName,
        Price = productPrice,
        Available = productAvailability,
        ProductTypeID = productTypeId
    };

    products.Add(newProduct);
    Console.WriteLine("\nProduct Added");

}

void UpdateProduct()
{
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
    Console.WriteLine("Select a Product to Update: \n");
    int productID = Convert.ToInt32(Console.ReadLine());

    Product updatedProduct = products.Find(product => product.ProductID == productID);

    if (updatedProduct != null)
    {
        Console.WriteLine("Enter a new name: ");
        string updatedName = Console.ReadLine();
        if (!string.IsNullOrEmpty(updatedName))
        {
            updatedProduct.Name = updatedName;
        }

        Console.WriteLine("Enter a new price: ");
        string updatedPrice = Console.ReadLine();
        if (!string.IsNullOrEmpty(updatedPrice))
        {
            updatedProduct.Price = Convert.ToDecimal(updatedPrice);
        }

        Console.WriteLine("Product still available? (True)|(False)");
        string updatedAvailability = Console.ReadLine().ToLower().Trim();
        if (!string.IsNullOrEmpty(updatedAvailability))
        {
            updatedProduct.Available = Convert.ToBoolean(updatedAvailability);
        }

        foreach (ProductType productType in productTypes)
        {
            Console.WriteLine($"{productType.ID}. {productType.Name}");
        }
        Console.Write("Choose a product type ID#: ");
        int updatedID = Convert.ToInt32(Console.ReadLine());
        if (updatedID != 0)
        {
            updatedProduct.ProductTypeID = updatedID;
        }

        Console.WriteLine("Product Updated");
    }
}

void DeleteProduct()
{
    foreach (Product product in products)
    {
        Console.WriteLine($"{product.ProductID}. {product.Name}");
    }

    Console.WriteLine("Enter product ID for deletion: ");
    int productID = Convert.ToInt32(Console.ReadLine());

    Product deletedProduct = products.Find(product => product.ProductID == productID);

    if (deletedProduct != null)
    {
        products.Remove(deletedProduct);
        Console.WriteLine("Product Deleted");
    }
}

string GetProductTypeName(int ProductTypeID, List<ProductType> productTypes)
{
    ProductType productType = productTypes.Find(product => product.ID == ProductTypeID);
    return productType != null ? productType.Name : "Unknown";
}

void ViewByType()
{
    Console.WriteLine("View Products by Type");
    Console.WriteLine("Product Types:");

    foreach (ProductType productType in productTypes)
    {
        Console.WriteLine($"\t{productType.ID}. {productType.Name}\n");
    }

    Console.Write("Enter product type ID# to view products: ");
    int productID = Convert.ToInt32(Console.ReadLine());

    var filteredProducts = products.Where(product => product.ProductTypeID == productID);

    if (filteredProducts.Any())
    {
        Console.WriteLine($"{GetProductTypeName(productID, productTypes)} Products");

        foreach (Product product in filteredProducts)
        {
            Console.WriteLine($"ID: {product.ProductID}, Name: {product.Name}, Price: ${product.Price}, In Stock: {product.Available}");
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}

void AvailableProducts()
{
    List<Product> availableProducts = products.Where(product => product.Available).ToList();

    Console.WriteLine(@"
+--------------------------------------------------------------+
|                                                              |
|                      Available Products                      |
|                                                              |
+--------------------------------------------------------------+");

    for (int i = 0; i < availableProducts.Count; i++)
    {
        Console.WriteLine($"{availableProducts[i].ProductID}   {availableProducts[i].Name}   Price: ${availableProducts[i].Price}   In Stock: {products[i].Available}   Type ID: {products[i].ProductTypeID}   DaysOnShelf: {products[i].DaysAvailable}");
    }
}