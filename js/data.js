// MusicStore - Static Data (Originally from SQL Server schema in C#)
// Tables: Users, Products, Orders, Categories

const STORE_DATA = {
    categories: [
        { CategoryID: 1, CategoryName: "גיטרות", Icon: "🎸" },
        { CategoryID: 2, CategoryName: "תופים", Icon: "🥁" },
        { CategoryID: 3, CategoryName: "פסנתרים", Icon: "🎹" },
        { CategoryID: 4, CategoryName: "כלי נשיפה", Icon: "🎺" },
        { CategoryID: 5, CategoryName: "אביזרים", Icon: "🎵" },
        { CategoryID: 6, CategoryName: "כלי קשת", Icon: "🎻" }
    ],

    products: [
        { ProductID: 1, ProductName: "Fender Stratocaster", Price: 4500, Description: "גיטרה חשמלית קלאסית של Fender. צליל נקי ועוצמתי, מתאימה לכל סגנון מוזיקלי. גוף עץ אלדר, צוואר מייפל.", Image: "https://images.unsplash.com/photo-1564186763535-ebb21ef5277f?w=600", CategoryID: 1, Stock: 12, Brand: "Fender" },
        { ProductID: 2, ProductName: "Gibson Les Paul Standard", Price: 8900, Description: "אחת הגיטרות החשמליות האגדיות בעולם. צליל חם ועשיר, מבנה מוצק עם פיקאפים Humbucker.", Image: "https://images.unsplash.com/photo-1525201548942-d8732f6617a0?w=600", CategoryID: 1, Stock: 5, Brand: "Gibson" },
        { ProductID: 3, ProductName: "Yamaha FG800 Acoustic", Price: 1200, Description: "גיטרה אקוסטית באיכות גבוהה במחיר נוח. צליל מאוזן ובהיר, מושלמת למתחילים ומתקדמים.", Image: "https://images.unsplash.com/photo-1510915361894-db8b60106cb1?w=600", CategoryID: 1, Stock: 20, Brand: "Yamaha" },
        { ProductID: 4, ProductName: "Ibanez RG550 Genesis", Price: 3800, Description: "גיטרה חשמלית מהירה ומדויקת לסגנונות רוק ומטאל. צוואר דק, פיקאפים חזקים.", Image: "https://images.unsplash.com/photo-1550985616-10810253b84d?w=600", CategoryID: 1, Stock: 8, Brand: "Ibanez" },
        { ProductID: 5, ProductName: "Pearl Export Drum Kit", Price: 5200, Description: "מערכת תופים מקצועית של Pearl. כוללת 5 חלקים, צלחות ברונזה איכותיות וחומרה יציבה.", Image: "https://images.unsplash.com/photo-1519892300165-cb5542fb47c7?w=600", CategoryID: 2, Stock: 4, Brand: "Pearl" },
        { ProductID: 6, ProductName: "Roland TD-17 Electronic Drums", Price: 7500, Description: "מערכת תופים אלקטרונית מתקדמת. רגישות גבוהה, צלילים מקצועיים, חיבור USB.", Image: "https://images.unsplash.com/photo-1543443258-92b04ad5ec4b?w=600", CategoryID: 2, Stock: 6, Brand: "Roland" },
        { ProductID: 7, ProductName: "Yamaha P-125 Digital Piano", Price: 3200, Description: "פסנתר דיגיטלי 88 קלידים משוקלל. צליל פסנתר אמיתי, קל לנשיאה, מושלם לבית ולבמה.", Image: "https://images.unsplash.com/photo-1520523839897-bd0b52f945a0?w=600", CategoryID: 3, Stock: 10, Brand: "Yamaha" },
        { ProductID: 8, ProductName: "Kawai ES110 Stage Piano", Price: 4100, Description: "פסנתר במה דיגיטלי מקצועי. מנגנון מקלדת RHC, צליל פסנתר Shigeru Kawai איכותי.", Image: "https://images.unsplash.com/photo-1571974599782-87624638275e?w=600", CategoryID: 3, Stock: 7, Brand: "Kawai" },
        { ProductID: 9, ProductName: "Yamaha YTR-2330 Trumpet", Price: 2400, Description: "חצוצרה אמינה ואיכותית. צליל בהיר ועקבי, מתאימה לתלמידים ולנגנים מתקדמים.", Image: "https://images.unsplash.com/photo-1612225330812-01a9c6b355ec?w=600", CategoryID: 4, Stock: 9, Brand: "Yamaha" },
        { ProductID: 10, ProductName: "Selmer Paris Saxophone", Price: 18500, Description: "סקסופון אלט מקצועי של Selmer Paris. עבודת יד צרפתית, צליל עשיר ועמוק.", Image: "https://images.unsplash.com/photo-1573871669414-010dbf73ca84?w=600", CategoryID: 4, Stock: 2, Brand: "Selmer" },
        { ProductID: 11, ProductName: "Shure SM58 Microphone", Price: 650, Description: "מיקרופון דינמי אגדי. סטנדרט תעשייתי לשירה חיה. עמיד וצליל מקצועי.", Image: "https://images.unsplash.com/photo-1590602847861-f357a9332bbc?w=600", CategoryID: 5, Stock: 30, Brand: "Shure" },
        { ProductID: 12, ProductName: "Boss DS-1 Distortion Pedal", Price: 380, Description: "פדל דיסטורשן קלאסי. צליל רוק מובהק, פשוט לשימוש, אמין לאורך שנים.", Image: "https://images.unsplash.com/photo-1558098329-a11cff621064?w=600", CategoryID: 5, Stock: 25, Brand: "Boss" },
        { ProductID: 13, ProductName: "Stentor Student II Violin", Price: 1450, Description: "כינור איכותי לסטודנטים. עץ ספרוס וטיגר מייפל, כולל קשת ונרתיק קשיח.", Image: "https://images.unsplash.com/photo-1612225330812-01a9c6b355ec?w=600", CategoryID: 6, Stock: 11, Brand: "Stentor" },
        { ProductID: 14, ProductName: "Cello 4/4 Professional", Price: 6200, Description: "צ'לו מקצועי בגודל מלא. עץ מיושן, צליל עמוק ועשיר, כולל קשת ונרתיק.", Image: "https://images.unsplash.com/photo-1465821185615-20b3c2fbf41b?w=600", CategoryID: 6, Stock: 3, Brand: "Cremona" }
    ],

    defaultUsers: [
        { UserID: 1, Name: "Admin", Email: "admin@musicstore.com", Password: "admin123", IsAdmin: true },
        { UserID: 2, Name: "Demo User", Email: "user@demo.com", Password: "demo123", IsAdmin: false }
    ]
};
