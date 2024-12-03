var booksNewIdx = 0;

function saveBook(authorId) {
    var title = $('#bookTitle').val(),
        genre = $('#bookGenre').val(),
        totalPages = $('#bookPages').val();

    if (title && genre && totalPages)
    {
        var newBook = {
            Title: title,
            Genre: genre,
            AuthorId: authorId,
            TotalPages: totalPages
        };

        $('#bookList').append(`
            <li class="list-group-item d-flex justify-content-between align-items-center">
                <div>
                    <i class="bi bi-book-fill text-primary me-2"></i>
                    <span class="fw-bold">${newBook.Title}</span>
                    <small class="text-muted">(${newBook.Genre}, ${newBook.TotalPages} pages)</small>
                </div>
                <button type="button" class="btn btn-danger btn-sm" data-book-id="${booksNewIdx}" onclick="removeNewBook(this)">
                    <i class="bi bi-trash"></i> Delete
                </button>
            </li>
        `);
        $('form').append('<input type="hidden" name="BooksNew[' + booksNewIdx + '].Title" value="' + newBook.Title + '" />');
        $('form').append('<input type="hidden" name="BooksNew[' + booksNewIdx + '].Genre" value="' + newBook.Genre + '" />');
        $('form').append('<input type="hidden" name="BooksNew[' + booksNewIdx + '].TotalPages" value="' + newBook.TotalPages + '" />');
        $('form').append('<input type="hidden" name="BooksNew[' + booksNewIdx + '].AuthorId" value="' + newBook.AuthorId + '" />');
        booksNewIdx++;
        $('#addBookModal').modal('hide');
        $('#addBookForm')[0].reset();
        refreshBookEmptyBlock();
    }
    else
    {
        alert('Please fill in all fields.');
    }
}

function removeExistBook(button) {
    const bookId = $(button).data('book-id');
    $(button).closest('li').remove();
    $('input[name="BooksExist[]"][value="' + bookId + '"]').remove();
    refreshBookEmptyBlock();
}

function removeNewBook(button) {
    const bookId = $(button).data('book-id');
    $(button).closest('li').remove();
    $('input[name="BooksNew[' + bookId + '].Title"]').remove();
    $('input[name="BooksNew[' + bookId + '].Genre"]').remove();
    $('input[name="BooksNew[' + bookId + '].TotalPages"]').remove();
    $('input[name="BooksNew[' + bookId + '].AuthorId"]').remove();
    refreshBookEmptyBlock();
}

function refreshBookEmptyBlock() {
    if (!$('#bookList .list-group-item').length)
    {
        $('#bookList').addClass('d-none');
        $('#bookListEmpty').removeClass('d-none');
    }
    else
    {
        $('#bookList').removeClass('d-none');
        $('#bookListEmpty').addClass('d-none');
    }
}
