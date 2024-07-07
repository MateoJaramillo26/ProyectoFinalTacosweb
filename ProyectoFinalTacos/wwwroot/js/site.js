// Write your JavaScript code.
function loadProducts() {
    fetch('/Productos/GetProducts')
        .then(response => response.json())
        .then(data => {
            const container = document.getElementById('product-grid');
            container.innerHTML = '';
            data.forEach(product => {
                const col = document.createElement('div');
                col.className = 'col-md-4 mb-5';
                col.innerHTML = `
                    <div class="card h-100">
                        <img class="card-img-top" src="${product.imagenProducto}" alt="${product.nombreProducto}" />
                        <div class="card-body">
                            <h2 class="card-title">${product.nombreProducto}</h2>
                            <p class="card-text">${product.descripcionProducto}</p>
                            <p class="card-text"><strong>Price:</strong> ${product.precioProducto.toFixed(2)}</p>
                        </div>
                        <div class="card-footer">
                            <a class="btn btn-primary btn-sm" asp-controller="Productos" asp-action="Details" asp-route-id="${product.idProducto}">Comprar</a>
                        </div>
                    </div>
                `;
                container.appendChild(col);
            });
        });
}

document.addEventListener('DOMContentLoaded', loadProducts);
