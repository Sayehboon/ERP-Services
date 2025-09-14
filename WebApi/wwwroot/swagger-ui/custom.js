// Simple Swagger UI Enhancements
window.addEventListener('load', function() {
    // Add JSON download link
    addJsonDownloadLink();
    
    // Add simple search functionality
    addSimpleSearch();
});

function addJsonDownloadLink() {
    const jsonLink = document.createElement('a');
    jsonLink.href = '/swagger/v1/swagger.json';
    jsonLink.target = '_blank';
    jsonLink.className = 'json-link';
    jsonLink.innerHTML = '📄 Download JSON';
    
    document.body.appendChild(jsonLink);
}

function addSimpleSearch() {
    // Wait for Swagger UI to load
    setTimeout(function() {
        const filterInput = document.querySelector('input[type="text"]');
        if (filterInput) {
            // Update placeholder
            filterInput.placeholder = 'جستجو در کنترلرها، متدها و توضیحات...';
            
            // Add simple search
            filterInput.addEventListener('input', function() {
                const searchTerm = this.value.toLowerCase().trim();
                if (searchTerm === '') {
                    clearSearch();
                    return;
                }
                
                // Simple search in all text content
                const allElements = document.querySelectorAll('*');
                let found = false;
                
                allElements.forEach(function(element) {
                    if (element.textContent && element.textContent.toLowerCase().includes(searchTerm)) {
                        // Find parent operation or controller
                        let container = element;
                        while (container && container !== document.body) {
                            if (container.className && typeof container.className === 'string' && (
                                container.className.includes('opblock') || 
                                container.className.includes('tag')
                            )) {
                                container.style.backgroundColor = '#e3f2fd';
                                container.style.border = '1px solid #2196f3';
                                found = true;
                                break;
                            }
                            container = container.parentElement;
                        }
                    }
                });
                
                if (!found) {
                    console.log('No matches found for:', searchTerm);
                }
            });
        }
    }, 2000);
}

function clearSearch() {
    // Clear all highlighting
    const allElements = document.querySelectorAll('*');
    allElements.forEach(function(element) {
        if (element.style.backgroundColor === 'rgb(227, 242, 253)' || 
            element.style.backgroundColor === '#e3f2fd') {
            element.style.backgroundColor = '';
            element.style.border = '';
        }
    });
}