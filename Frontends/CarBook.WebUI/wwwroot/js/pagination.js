function createPagination(containerSelector, totalPages, currentPage, onPageClick) {
    const container = $(containerSelector);
    let html = '';

    if (currentPage > 1) {
        html += `<li><a href="#" data-page="${currentPage - 1}">&lt;</a></li>`;
    }

    for (let i = 1; i <= totalPages; i++) {
        if (i === currentPage) {
            html += `<li class="active"><span>${i}</span></li>`;
        } else {
            html += `<li><a href="#" data-page="${i}">${i}</a></li>`;
        }
    }

    if (currentPage < totalPages) {
        html += `<li><a href="#" data-page="${currentPage + 1}">&gt;</a></li>`;
    }

    container.html(html);

    container.find('a').on('click', function (e) {
        e.preventDefault();
        const page = $(this).data('page');
        if (typeof onPageClick === 'function') {
            onPageClick(page);
        }
    });
}