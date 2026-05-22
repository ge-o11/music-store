// MusicStore - Shared Frontend Logic (uses localStorage as "database")

const DB = {
    init() {
        if (!localStorage.getItem('ms_users')) {
            localStorage.setItem('ms_users', JSON.stringify(STORE_DATA.defaultUsers));
        }
        if (!localStorage.getItem('ms_products')) {
            localStorage.setItem('ms_products', JSON.stringify(STORE_DATA.products));
        }
        if (!localStorage.getItem('ms_orders')) {
            localStorage.setItem('ms_orders', JSON.stringify([]));
        }
    },
    getUsers() { return JSON.parse(localStorage.getItem('ms_users') || '[]'); },
    saveUsers(u) { localStorage.setItem('ms_users', JSON.stringify(u)); },
    getProducts() { return JSON.parse(localStorage.getItem('ms_products') || '[]'); },
    saveProducts(p) { localStorage.setItem('ms_products', JSON.stringify(p)); },
    getOrders() { return JSON.parse(localStorage.getItem('ms_orders') || '[]'); },
    saveOrders(o) { localStorage.setItem('ms_orders', JSON.stringify(o)); },
    getCategories() { return STORE_DATA.categories; },
    getCategoryById(id) { return STORE_DATA.categories.find(c => c.CategoryID === Number(id)); },
    getProductById(id) { return this.getProducts().find(p => p.ProductID === Number(id)); }
};

const Auth = {
    getCurrentUser() {
        const data = sessionStorage.getItem('ms_currentUser');
        return data ? JSON.parse(data) : null;
    },
    login(email, password) {
        const user = DB.getUsers().find(u => u.Email.toLowerCase() === email.toLowerCase() && u.Password === password);
        if (user) {
            sessionStorage.setItem('ms_currentUser', JSON.stringify(user));
            return user;
        }
        return null;
    },
    register(name, email, password) {
        const users = DB.getUsers();
        if (users.find(u => u.Email.toLowerCase() === email.toLowerCase())) return null;
        const newUser = {
            UserID: Math.max(0, ...users.map(u => u.UserID)) + 1,
            Name: name, Email: email, Password: password, IsAdmin: false
        };
        users.push(newUser);
        DB.saveUsers(users);
        sessionStorage.setItem('ms_currentUser', JSON.stringify(newUser));
        return newUser;
    },
    logout() { sessionStorage.removeItem('ms_currentUser'); },
    isAdmin() { const u = this.getCurrentUser(); return u && u.IsAdmin; }
};

const Cart = {
    getItems() { return JSON.parse(sessionStorage.getItem('ms_cart') || '[]'); },
    save(items) {
        sessionStorage.setItem('ms_cart', JSON.stringify(items));
        this.updateBadge();
    },
    add(productId, quantity = 1) {
        const product = DB.getProductById(productId);
        if (!product) return;
        const items = this.getItems();
        const existing = items.find(i => i.ProductID === product.ProductID);
        if (existing) existing.Quantity += quantity;
        else items.push({ ProductID: product.ProductID, ProductName: product.ProductName, Price: product.Price, Image: product.Image, Quantity: quantity });
        this.save(items);
    },
    update(productId, quantity) {
        let items = this.getItems();
        if (quantity <= 0) items = items.filter(i => i.ProductID !== productId);
        else { const it = items.find(i => i.ProductID === productId); if (it) it.Quantity = quantity; }
        this.save(items);
    },
    remove(productId) { this.save(this.getItems().filter(i => i.ProductID !== productId)); },
    clear() { sessionStorage.removeItem('ms_cart'); this.updateBadge(); },
    total() { return this.getItems().reduce((s, i) => s + i.Price * i.Quantity, 0); },
    count() { return this.getItems().reduce((s, i) => s + i.Quantity, 0); },
    updateBadge() {
        const badges = document.querySelectorAll('.cart-count');
        const c = this.count();
        badges.forEach(b => { b.textContent = c; b.style.display = c > 0 ? 'inline-flex' : 'none'; });
    }
};

function showAlert(msg, type = 'success') {
    const div = document.createElement('div');
    div.className = `alert alert-${type}`;
    div.textContent = msg;
    document.body.insertBefore(div, document.querySelector('main'));
    setTimeout(() => { div.style.opacity = '0'; setTimeout(() => div.remove(), 300); }, 4000);
}

function formatPrice(n) { return Number(n).toLocaleString('he-IL'); }

function renderHeader() {
    const user = Auth.getCurrentUser();
    const cartCount = Cart.count();
    document.getElementById('header').innerHTML = `
        <header class="navbar">
            <div class="container nav-container">
                <a class="logo" href="index.html">
                    <span class="logo-icon">🎵</span>
                    <span class="logo-text">Music<span class="logo-accent">Store</span></span>
                </a>
                <nav class="main-nav">
                    <a href="index.html">בית</a>
                    <a href="products.html">מוצרים</a>
                    <a href="about.html">אודות</a>
                    <a href="contact.html">צור קשר</a>
                    ${user && user.IsAdmin ? '<a href="admin.html" class="admin-link">לוח ניהול</a>' : ''}
                </nav>
                <div class="nav-actions">
                    <a href="cart.html" class="cart-btn" title="עגלה" style="position:relative;">
                        <svg width="22" height="22" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                            <circle cx="9" cy="21" r="1"></circle><circle cx="20" cy="21" r="1"></circle>
                            <path d="M1 1h4l2.68 13.39a2 2 0 0 0 2 1.61h9.72a2 2 0 0 0 2-1.61L23 6H6"></path>
                        </svg>
                        ${cartCount > 0 ? `<span class="cart-count" style="position:absolute;top:-6px;left:-6px;background:var(--gold);color:var(--bg-primary);border-radius:50%;width:20px;height:20px;font-size:11px;font-weight:800;display:inline-flex;align-items:center;justify-content:center;">${cartCount}</span>` : ''}
                    </a>
                    ${user ? `
                        <div class="user-menu">
                            <span class="user-name">שלום, ${user.Name}</span>
                            <div class="user-dropdown">
                                <a href="my-orders.html">ההזמנות שלי</a>
                                <a href="javascript:void(0)" onclick="Auth.logout(); location.href='index.html'">התנתק</a>
                            </div>
                        </div>
                    ` : `
                        <a href="login.html" class="btn-login">התחבר</a>
                        <a href="register.html" class="btn-register">הרשמה</a>
                    `}
                </div>
            </div>
        </header>
    `;
}

function renderFooter() {
    document.getElementById('footer').innerHTML = `
        <footer class="site-footer">
            <div class="container footer-content">
                <div class="footer-col">
                    <h3>Music<span class="logo-accent">Store</span></h3>
                    <p>חנות כלי הנגינה המובילה. איכות, מגוון ושירות מקצועי מאז 1995.</p>
                </div>
                <div class="footer-col">
                    <h4>קטגוריות</h4>
                    <a href="products.html?categoryId=1">גיטרות</a>
                    <a href="products.html?categoryId=2">תופים</a>
                    <a href="products.html?categoryId=3">פסנתרים</a>
                    <a href="products.html?categoryId=4">כלי נשיפה</a>
                </div>
                <div class="footer-col">
                    <h4>שירות לקוחות</h4>
                    <a href="contact.html">צור קשר</a>
                    <a href="about.html">אודות</a>
                    <a href="#">מדיניות החזרות</a>
                    <a href="#">משלוחים</a>
                </div>
                <div class="footer-col">
                    <h4>צור קשר</h4>
                    <p>📞 03-1234567</p>
                    <p>✉️ info@musicstore.co.il</p>
                    <p>📍 דיזנגוף 100, תל אביב</p>
                </div>
            </div>
            <div class="footer-bottom">
                <div class="container"><p>&copy; 2026 MusicStore. כל הזכויות שמורות.</p></div>
            </div>
        </footer>
    `;
}

function renderProductCard(p) {
    return `
        <div class="product-card">
            <div class="product-image">
                <img src="${p.Image}" alt="${p.ProductName}" loading="lazy" />
                ${p.Stock < 5 ? '<span class="product-badge">אחרונים</span>' : ''}
            </div>
            <div class="product-info">
                <div class="product-brand">${p.Brand}</div>
                <div class="product-name">${p.ProductName}</div>
                <div class="product-price"><span class="currency">₪</span>${formatPrice(p.Price)}</div>
                <div class="product-actions">
                    <a href="product.html?id=${p.ProductID}" class="btn-view">פרטים</a>
                    <button class="btn-add-cart" onclick="Cart.add(${p.ProductID}); showAlert('${p.ProductName.replace(/'/g, "\\'")} נוסף לעגלה');">+ עגלה</button>
                </div>
            </div>
        </div>
    `;
}

function getQueryParam(name) {
    return new URLSearchParams(window.location.search).get(name);
}

document.addEventListener('DOMContentLoaded', () => {
    DB.init();
    if (document.getElementById('header')) renderHeader();
    if (document.getElementById('footer')) renderFooter();
});
