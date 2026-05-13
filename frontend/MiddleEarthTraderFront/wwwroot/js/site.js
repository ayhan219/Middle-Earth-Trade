// Modal açma/kapama
const aboutCard = document.getElementById('aboutGameCard');
const aboutModal = document.getElementById('aboutModal');
const closeModal = document.getElementById('closeModal');

if (aboutCard && aboutModal && closeModal) {
    aboutCard.addEventListener('click', () => {
        aboutModal.classList.add('active');
    });
    closeModal.addEventListener('click', () => {
        aboutModal.classList.remove('active');
    });
    window.addEventListener('keydown', (e) => {
        if (e.key === 'Escape') aboutModal.classList.remove('active');
    });
    aboutModal.addEventListener('click', (e) => {
        if (e.target === aboutModal) aboutModal.classList.remove('active');
    });
}

document.addEventListener('DOMContentLoaded', () => {
    checkAuthState();
});

function checkAuthState() {
    const playerId = localStorage.getItem("id");
    const authButtons = document.getElementById("auth-buttons-container");
    
    if (authButtons) {
        if (playerId) {
            authButtons.innerHTML = `
                <button class="btn btn-login" onclick="logout()">Logout</button>
            `;
        } else {
            // Check if we are on the home page with the login modal available
            if (document.getElementById('openLoginModal')) {
                authButtons.innerHTML = `
                    <button class="btn btn-login" id="openLoginModal" onclick="openLoginModal()">Login</button>
                    <button class="btn btn-register">Register</button>
                `;
            } else {
                authButtons.innerHTML = ``;
            }
        }
    }
    
    if (playerId) {
        // Hide Play Now if we are on the hero section
        const heroButtons = document.querySelector('.hero-buttons');
        if (heroButtons) {
            heroButtons.innerHTML = `<a href="/Profile" class="btn btn-login">My Profile</a>`;
        }
    } else {
        // Enforce redirect for protected pages
        const path = window.location.pathname.toLowerCase();
        if (path.includes('/profile')) {
            window.location.href = '/';
        }
    }
}

function logout() {
    localStorage.removeItem("id");
    
    // Clear cookies
    document.cookie = "met_username=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    document.cookie = "met_password=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    
    window.location.href = "/";
}
