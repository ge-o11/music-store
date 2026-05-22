using MusicStore.Models;

namespace MusicStore.Data;

public class InMemoryDatabase
{
    public List<User> Users { get; private set; }
    public List<Product> Products { get; private set; }
    public List<Order> Orders { get; private set; }
    public List<Category> Categories { get; private set; }

    private int _userIdCounter = 1;
    private int _productIdCounter = 1;
    private int _orderIdCounter = 1;
    private int _categoryIdCounter = 1;

    private readonly object _lock = new();

    public InMemoryDatabase()
    {
        Users = new List<User>();
        Products = new List<Product>();
        Orders = new List<Order>();
        Categories = new List<Category>();
        SeedData();
    }

    private void SeedData()
    {
        // Default admin user
        Users.Add(new User
        {
            UserID = _userIdCounter++,
            Name = "Admin",
            Email = "admin@musicstore.com",
            Password = "admin123",
            IsAdmin = true
        });

        Users.Add(new User
        {
            UserID = _userIdCounter++,
            Name = "Demo User",
            Email = "user@demo.com",
            Password = "demo123",
            IsAdmin = false
        });

        // Categories
        Categories.Add(new Category { CategoryID = _categoryIdCounter++, CategoryName = "גיטרות", Icon = "🎸" });
        Categories.Add(new Category { CategoryID = _categoryIdCounter++, CategoryName = "תופים", Icon = "🥁" });
        Categories.Add(new Category { CategoryID = _categoryIdCounter++, CategoryName = "פסנתרים", Icon = "🎹" });
        Categories.Add(new Category { CategoryID = _categoryIdCounter++, CategoryName = "כלי נשיפה", Icon = "🎺" });
        Categories.Add(new Category { CategoryID = _categoryIdCounter++, CategoryName = "אביזרים", Icon = "🎵" });
        Categories.Add(new Category { CategoryID = _categoryIdCounter++, CategoryName = "כלי קשת", Icon = "🎻" });

        // Products - גיטרות
        Products.Add(new Product
        {
            ProductID = _productIdCounter++,
            ProductName = "Fender Stratocaster",
            Price = 4500,
            Description = "גיטרה חשמלית קלאסית של Fender. צליל נקי ועוצמתי, מתאימה לכל סגנון מוזיקלי. גוף עץ אלדר, צוואר מייפל.",
            Image = "https://images.unsplash.com/photo-1564186763535-ebb21ef5277f?w=600",
            CategoryID = 1,
            Stock = 12,
            Brand = "Fender"
        });

        Products.Add(new Product
        {
            ProductID = _productIdCounter++,
            ProductName = "Gibson Les Paul Standard",
            Price = 8900,
            Description = "אחת הגיטרות החשמליות האגדיות בעולם. צליל חם ועשיר, מבנה מוצק עם פיקאפים Humbucker.",
            Image = "https://images.unsplash.com/photo-1525201548942-d8732f6617a0?w=600",
            CategoryID = 1,
            Stock = 5,
            Brand = "Gibson"
        });

        Products.Add(new Product
        {
            ProductID = _productIdCounter++,
            ProductName = "Yamaha FG800 Acoustic",
            Price = 1200,
            Description = "גיטרה אקוסטית באיכות גבוהה במחיר נוח. צליל מאוזן ובהיר, מושלמת למתחילים ומתקדמים.",
            Image = "https://images.unsplash.com/photo-1510915361894-db8b60106cb1?w=600",
            CategoryID = 1,
            Stock = 20,
            Brand = "Yamaha"
        });

        Products.Add(new Product
        {
            ProductID = _productIdCounter++,
            ProductName = "Ibanez RG550 Genesis",
            Price = 3800,
            Description = "גיטרה חשמלית מהירה ומדויקת לסגנונות רוק ומטאל. צוואר דק, פיקאפים חזקים.",
            Image = "https://images.unsplash.com/photo-1550985616-10810253b84d?w=600",
            CategoryID = 1,
            Stock = 8,
            Brand = "Ibanez"
        });

        // תופים
        Products.Add(new Product
        {
            ProductID = _productIdCounter++,
            ProductName = "Pearl Export Drum Kit",
            Price = 5200,
            Description = "מערכת תופים מקצועית של Pearl. כוללת 5 חלקים, צלחות ברונזה איכותיות וחומרה יציבה.",
            Image = "https://images.unsplash.com/photo-1519892300165-cb5542fb47c7?w=600",
            CategoryID = 2,
            Stock = 4,
            Brand = "Pearl"
        });

        Products.Add(new Product
        {
            ProductID = _productIdCounter++,
            ProductName = "Roland TD-17 Electronic Drums",
            Price = 7500,
            Description = "מערכת תופים אלקטרונית מתקדמת. רגישות גבוהה, צלילים מקצועיים, חיבור USB.",
            Image = "https://images.unsplash.com/photo-1543443258-92b04ad5ec4b?w=600",
            CategoryID = 2,
            Stock = 6,
            Brand = "Roland"
        });

        // פסנתרים
        Products.Add(new Product
        {
            ProductID = _productIdCounter++,
            ProductName = "Yamaha P-125 Digital Piano",
            Price = 3200,
            Description = "פסנתר דיגיטלי 88 קלידים משוקלל. צליל פסנתר אמיתי, קל לנשיאה, מושלם לבית ולבמה.",
            Image = "https://images.unsplash.com/photo-1520523839897-bd0b52f945a0?w=600",
            CategoryID = 3,
            Stock = 10,
            Brand = "Yamaha"
        });

        Products.Add(new Product
        {
            ProductID = _productIdCounter++,
            ProductName = "Kawai ES110 Stage Piano",
            Price = 4100,
            Description = "פסנתר במה דיגיטלי מקצועי. מנגנון מקלדת RHC, צליל פסנתר Shigeru Kawai איכותי.",
            Image = "https://images.unsplash.com/photo-1571974599782-87624638275e?w=600",
            CategoryID = 3,
            Stock = 7,
            Brand = "Kawai"
        });

        // כלי נשיפה
        Products.Add(new Product
        {
            ProductID = _productIdCounter++,
            ProductName = "Yamaha YTR-2330 Trumpet",
            Price = 2400,
            Description = "חצוצרה אמינה ואיכותית. צליל בהיר ועקבי, מתאימה לתלמידים ולנגנים מתקדמים.",
            Image = "https://images.unsplash.com/photo-1612225330812-01a9c6b355ec?w=600",
            CategoryID = 4,
            Stock = 9,
            Brand = "Yamaha"
        });

        Products.Add(new Product
        {
            ProductID = _productIdCounter++,
            ProductName = "Selmer Paris Saxophone",
            Price = 18500,
            Description = "סקסופון אלט מקצועי של Selmer Paris. עבודת יד צרפתית, צליל עשיר ועמוק.",
            Image = "https://images.unsplash.com/photo-1573871669414-010dbf73ca84?w=600",
            CategoryID = 4,
            Stock = 2,
            Brand = "Selmer"
        });

        // אביזרים
        Products.Add(new Product
        {
            ProductID = _productIdCounter++,
            ProductName = "Shure SM58 Microphone",
            Price = 650,
            Description = "מיקרופון דינמי אגדי. סטנדרט תעשייתי לשירה חיה. עמיד וצליל מקצועי.",
            Image = "https://images.unsplash.com/photo-1590602847861-f357a9332bbc?w=600",
            CategoryID = 5,
            Stock = 30,
            Brand = "Shure"
        });

        Products.Add(new Product
        {
            ProductID = _productIdCounter++,
            ProductName = "Boss DS-1 Distortion Pedal",
            Price = 380,
            Description = "פדל דיסטורשן קלאסי. צליל רוק מובהק, פשוט לשימוש, אמין לאורך שנים.",
            Image = "https://images.unsplash.com/photo-1558098329-a11cff621064?w=600",
            CategoryID = 5,
            Stock = 25,
            Brand = "Boss"
        });

        // כלי קשת
        Products.Add(new Product
        {
            ProductID = _productIdCounter++,
            ProductName = "Stentor Student II Violin",
            Price = 1450,
            Description = "כינור איכותי לסטודנטים. עץ ספרוס וטיגר מייפל, כולל קשת ונרתיק קשיח.",
            Image = "https://images.unsplash.com/photo-1612225330812-01a9c6b355ec?w=600",
            CategoryID = 6,
            Stock = 11,
            Brand = "Stentor"
        });

        Products.Add(new Product
        {
            ProductID = _productIdCounter++,
            ProductName = "Cello 4/4 Professional",
            Price = 6200,
            Description = "צ'לו מקצועי בגודל מלא. עץ מיושן, צליל עמוק ועשיר, כולל קשת ונרתיק.",
            Image = "https://images.unsplash.com/photo-1465821185615-20b3c2fbf41b?w=600",
            CategoryID = 6,
            Stock = 3,
            Brand = "Cremona"
        });
    }

    // User methods
    public User? GetUserByEmail(string email)
    {
        return Users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public User? GetUserById(int id)
    {
        return Users.FirstOrDefault(u => u.UserID == id);
    }

    public User AddUser(User user)
    {
        lock (_lock)
        {
            user.UserID = _userIdCounter++;
            Users.Add(user);
            return user;
        }
    }

    // Product methods
    public Product? GetProductById(int id)
    {
        return Products.FirstOrDefault(p => p.ProductID == id);
    }

    public List<Product> GetProductsByCategory(int categoryId)
    {
        return Products.Where(p => p.CategoryID == categoryId).ToList();
    }

    public List<Product> SearchProducts(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return Products.ToList();

        keyword = keyword.ToLower();
        return Products.Where(p =>
            p.ProductName.ToLower().Contains(keyword) ||
            p.Description.ToLower().Contains(keyword) ||
            p.Brand.ToLower().Contains(keyword)).ToList();
    }

    public Product AddProduct(Product product)
    {
        lock (_lock)
        {
            product.ProductID = _productIdCounter++;
            Products.Add(product);
            return product;
        }
    }

    public bool UpdateProduct(Product product)
    {
        lock (_lock)
        {
            var existing = GetProductById(product.ProductID);
            if (existing == null) return false;
            existing.ProductName = product.ProductName;
            existing.Price = product.Price;
            existing.Description = product.Description;
            existing.Image = product.Image;
            existing.CategoryID = product.CategoryID;
            existing.Stock = product.Stock;
            existing.Brand = product.Brand;
            return true;
        }
    }

    public bool DeleteProduct(int id)
    {
        lock (_lock)
        {
            var product = GetProductById(id);
            if (product == null) return false;
            Products.Remove(product);
            return true;
        }
    }

    // Order methods
    public Order AddOrder(Order order)
    {
        lock (_lock)
        {
            order.OrderID = _orderIdCounter++;
            Orders.Add(order);
            return order;
        }
    }

    public List<Order> GetOrdersByUserId(int userId)
    {
        return Orders.Where(o => o.UserID == userId).OrderByDescending(o => o.OrderDate).ToList();
    }

    // Category methods
    public Category? GetCategoryById(int id)
    {
        return Categories.FirstOrDefault(c => c.CategoryID == id);
    }
}
