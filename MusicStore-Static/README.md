# 🎵 MusicStore - Static Version (Cloudflare Pages Ready)

גרסה סטטית של אתר MusicStore מוכנה להעלאה ל-**Cloudflare Pages**.

## 📤 איך מעלים ל-Cloudflare Pages?

### שיטה 1: גרירה ושחרור (הכי קל)

1. היכנס ל-**https://dash.cloudflare.com**
2. אם אין לך חשבון - הירשם (חינם)
3. בתפריט השמאלי בחר **Workers & Pages**
4. לחץ **Create application** → **Pages** → **Upload assets**
5. תן שם לפרויקט (למשל: `music-store`)
6. **גרור את הקובץ `MusicStore-Static.zip`** או את כל התיקייה
7. לחץ **Deploy site**
8. בתוך 30 שניות תקבל קישור כמו: `https://music-store.pages.dev`

### שיטה 2: דרך Wrangler CLI
```bash
npm install -g wrangler
wrangler pages deploy MusicStore-Static --project-name=music-store
```

## 📁 מבנה הפרויקט

```
MusicStore-Static/
├── index.html              דף הבית
├── products.html           רשימת מוצרים
├── product.html            פרטי מוצר
├── cart.html               עגלת קניות
├── login.html              התחברות
├── register.html           הרשמה
├── admin.html              לוח ניהול
├── about.html              אודות
├── contact.html            צור קשר
├── order-confirmation.html אישור הזמנה
├── my-orders.html          ההזמנות שלי
├── css/site.css            עיצוב מודרני
└── js/
    ├── data.js             הנתונים (מקביל ל-SQL Server)
    └── app.js              לוגיקה משותפת
```

## 👤 משתמשי דמו

| תפקיד | אימייל | סיסמה |
|------|--------|--------|
| 👑 מנהל | admin@musicstore.com | admin123 |
| 👤 לקוח | user@demo.com | demo123 |

## 💾 איך הנתונים נשמרים?

מכיוון שזו גרסה סטטית, הנתונים נשמרים ב-**localStorage** של הדפדפן:
- מוצרים, משתמשים והזמנות → `localStorage`
- משתמש מחובר ועגלת קניות → `sessionStorage`

## ⚠️ ההבדל מגרסת C# המקורית

הגרסה המלאה ב-C# / ASP.NET Core / SQL Server נמצאת ב: `C:\Users\jorj\MusicStore`
- אותה דאטה (4 טבלאות לפי מסמך המרצה)
- אותו עיצוב במדויק
- כל הפונקציונליות זהה

Cloudflare תומך רק באתרים סטטיים, לכן הומר ל-HTML/JS.
