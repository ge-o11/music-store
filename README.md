# 🎵 MusicStore — חנות כלי נגינה אונליין

פרויקט אתר מסחר אלקטרוני (E-Commerce) לחנות כלי נגינה. הריפו מכיל **שתי גרסאות** של אותו הפרויקט.

---

## 📦 שתי גרסאות

### 1. `MusicStore/` — גרסת C# מלאה (ASP.NET Core MVC)
הגרסה לפי דרישות המרצה: C# Backend + SQL Server schema (In-Memory) + HTML Views.

**טכנולוגיות:**
- Backend: **C# / ASP.NET Core 8.0 MVC**
- Frontend: **HTML5 + CSS3** (Razor Views)
- Database: **In-Memory** (מסד נתונים בתוך הקוד, לפי מבנה SQL Server מה-PDF)
- Session: ASP.NET Core Session

**הרצה מקומית:**
```bash
cd MusicStore
dotnet restore
dotnet run
```
פתח: <http://localhost:5000>

---

### 2. `MusicStore-Static/` — גרסת HTML/JS סטטית
המרה של הפרויקט ל-HTML+CSS+JS, מתאים לפריסה ל-**Cloudflare Pages / Netlify / GitHub Pages**.

הנתונים נשמרים ב-`localStorage` של הדפדפן (במקום SQL).

**הרצה מקומית:**
פשוט פתח את `index.html` בדפדפן.

**פריסה ל-Cloudflare Pages:**
דרגגראגה של התיקייה לתוך dash.cloudflare.com → Workers & Pages → Upload assets.

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
