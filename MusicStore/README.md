# 🎵 MusicStore - חנות כלי נגינה אונליין

פרויקט אתר מסחר אלקטרוני (E-Commerce) לחנות כלי נגינה, כתוב ב-**C# / ASP.NET Core MVC**.

## 🛠️ טכנולוגיות

- **Backend:** C# / ASP.NET Core 8.0 MVC
- **Frontend:** HTML5 + CSS3 (Razor Views)
- **Database:** In-Memory Database (מימוש פנימי בקוד C#) - מדמה את מבנה SQL Server לפי ה-PDF
- **Session Management:** ASP.NET Core Session

## 📋 דרישות מערכת

- **.NET 8.0 SDK** - הורד מ-https://dotnet.microsoft.com/download/dotnet/8.0

## 🚀 הוראות הרצה

פתח **PowerShell** או **CMD** בתיקיית הפרויקט והרץ:

```bash
cd C:\Users\jorj\MusicStore
dotnet restore
dotnet run
```

לאחר ההרצה פתח בדפדפן:
- **https://localhost:5001**
- או **http://localhost:5000**

## 👤 משתמשי דמו

| תפקיד | אימייל | סיסמה |
|------|--------|--------|
| 👑 מנהל | admin@musicstore.com | admin123 |
| 👤 לקוח | user@demo.com | demo123 |

## 📁 מבנה הפרויקט

```
MusicStore/
├── Models/                  # מחלקות המודל
│   ├── Product.cs
│   ├── User.cs
│   ├── Order.cs
│   ├── Category.cs
│   └── CartItem.cs
├── Data/
│   └── InMemoryDatabase.cs  # "מסד הנתונים" בתוך הקוד
├── Controllers/             # MVC Controllers
│   ├── HomeController.cs
│   ├── ProductsController.cs
│   ├── CartController.cs
│   ├── AccountController.cs
│   └── AdminController.cs
├── Views/                   # תבניות HTML (Razor)
│   ├── Home/
│   ├── Products/
│   ├── Cart/
│   ├── Account/
│   ├── Admin/
│   └── Shared/_Layout.cshtml
├── wwwroot/
│   └── css/site.css         # עיצוב מודרני
└── Program.cs               # נקודת הכניסה
```

## ✨ פיצ'רים

### למשתמש רגיל:
- ✅ דף בית מעוצב עם קטגוריות ומוצרים נבחרים
- ✅ קטלוג מוצרים עם סינון וחיפוש
- ✅ דף פרטי מוצר עם תמונה ומחיר
- ✅ עגלת קניות עם עדכון כמויות
- ✅ הרשמה והתחברות
- ✅ ביצוע הזמנה והיסטוריית הזמנות

### למנהל:
- ✅ לוח ניהול עם סטטיסטיקות
- ✅ הוספה / עריכה / מחיקה של מוצרים
- ✅ ניהול הזמנות
- ✅ צפייה ברשימת משתמשים

## 🗄️ מבנה מסד הנתונים

לפי הגדרות ה-PDF המקורי:

| טבלה | עמודות |
|------|---------|
| **Users** | UserID, Name, Email, Password, IsAdmin |
| **Products** | ProductID, ProductName, Price, Description, Image, CategoryID, Stock, Brand |
| **Orders** | OrderID, UserID, TotalPrice, OrderDate, Status, Items |
| **Categories** | CategoryID, CategoryName, Icon |

## 🎨 עיצוב

- ערכת נושא **כהה מודרנית** עם הדגשות זהב
- פונט **Heebo** + **Playfair Display**
- תמיכה מלאה ב-**RTL** (עברית)
- **Responsive** - מתאים לכל גודל מסך
