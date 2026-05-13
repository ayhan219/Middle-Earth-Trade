document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('loginForm');
    if (!form) return;
    form.addEventListener('submit', async function(e) {
        e.preventDefault();
        const username = document.getElementById('username').value;
        const password = document.getElementById('password').value;
        console.log("username", username)
        try {
            const response = await (window.api ? api.post('/api/Users/login', {
                username: username,
                password: password
            }) : axios.post((window.API_BASE_URL || '') + '/api/Users/login', { username: username, password: password }));
            document.getElementById('result').innerText = JSON.stringify(response.data);
        } catch (error) {
            document.getElementById('result').innerText = 'Giriş başarısız: ' + (error.response ? error.response.data : error.message);
        }
    });
}); 