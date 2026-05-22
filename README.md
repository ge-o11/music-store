# 🎵 MusicStore — חנות כלי נגינה אונליין

פרויקט אתר מסחר אלקטרוני (E-Commerce) לחנות כלי נגינה.

🌐 **דמו חי:** https://music-store.pages.dev

---

## 📦 הריפו מכיל שתי גרסאות

### 1. גרסה סטטית (HTML/CSS/JS) — בשורש הריפו
מתאימה לפריסה ב-**Cloudflare Pages / Netlify / GitHub Pages**.
הנתונים נשמרים ב-`localStorage` של הדפדפן.

**הרצה מקומית:** פתח את `index.html` בדפדפן.

### 2. גרסת C# (ASP.NET Core MVC) — תיקיית `MusicStore/`
הגרסה המקצועית לפי דרישות המרצה: C# Backend + מבנה SQL Server (In-Memory) + Razor Views.

**הרצה מקומית:**
```bash
cd MusicStore
dotnet restore
dotnet run
```
פתח: <http://localhost:5000>

---

## 👤 משתמשי דמו

| תפקיד | אימייל | סיסמה |
|------|--------|--------|
| 👑 מנהל | admin@musicstore.com | admin123 |
| 👤 לקוח | user@demo.com | demo123 |

---

## 🗄️ מבנה מסד הנתונים (לפי מסמך המרצה)

| טבלה | עמודות |
|------|---------|
| **Users** | UserID, Name, Email, Password, IsAdmin |
| **Products** | ProductID, ProductName, Price, Description, Image, CategoryID, Stock, Brand |
| **Orders** | OrderID, UserID, TotalPrice, OrderDate, Status, Items |
| **Categories** | CategoryID, CategoryName, Icon |

---

## ✨ פיצ'רים

### למשתמש:
- ✅ דף בית מעוצב עם קטגוריות ומוצרים נבחרים
- ✅ קטלוג מוצרים עם סינון וחיפוש
- ✅ דף פרטי מוצר
- ✅ עגלת קניות (הוספה / עדכון / מחיקה)
- ✅ הרשמה והתחברות
- ✅ ביצוע הזמנה והיסטוריה

### למנהל:
- ✅ לוח ניהול עם סטטיסטיקות
- ✅ הוספה / עריכה / מחיקה של מוצרים
- ✅ ניהול הזמנות
- ✅ צפייה ברשימת משתמשים

---

## 🎨 עיצוב
- ערכת נושא **כהה מודרנית** עם הדגשות זהב
- פונט **Heebo** + **Playfair Display**
- תמיכה מלאה ב-**RTL** (עברית)
- **Responsive** לכל גודל מסך
