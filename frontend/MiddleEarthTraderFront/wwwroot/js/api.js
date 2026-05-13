(function(){
	var base = (window && window.API_BASE_URL) || location.origin;
	if (typeof axios === 'undefined') {
		console.error('Axios not found. Ensure axios is loaded before api.js');
		return;
	}
	window.api = axios.create({
		baseURL: base,
		headers: { 'Content-Type': 'application/json' }
	});
})();


