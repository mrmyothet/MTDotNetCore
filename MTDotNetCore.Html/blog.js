const tblBlog = "blogs";
let editBlogId = null;

console.log("Hello World from Console");

// readBlog();
getBlogTable();

// createBlog("test title", "test author", "test content");
// updateBlog("800343db-584d-4a43-90bb-4ce39cbdb95d", "title", "author", "content");
// deleteBlog("7cdeb770-5e83-4b56-b00e-0391ecd544d5");


function readBlog() {
    let lst = getBlogs();
    console.log(lst);
}

function createBlog(title, author, content) {

    let requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content
    };

    let lst = getBlogs();
    lst.push(requestModel);

    const jsonList = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonList);
}

function updateBlog(id, UpdateTitle, updateAuthor, updateContent) {
    let lst = getBlogs();

    let items = lst.filter(x => x.id === id);
    if (items.length < 1) {
        console.log("No data found with Id: " + id);
        return;
    }

    let updateItem = items[0];
    updateItem.title = UpdateTitle;
    updateItem.author = updateAuthor;
    updateItem.content = updateContent;

    const index = lst.findIndex(x => x.id === id);
    lst[index] = updateItem;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
}

function deleteBlog(id) {
    let lst = getBlogs();

    let item = lst.filter(x => x.id === id);
    if (item.length === 0) {
        console.log("No data found with Id: " + id);
        return;
    }

    // Get the remaining items only
    lst = lst.filter(x => x.id !== id);

    const jsonBlogs = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlogs);
}

function getBlogs() {
    let lst = [];
    const blogs = localStorage.getItem(tblBlog);
    if (blogs === null) {
        console.log("There is no data in the database.");
        return lst;
    }

    lst = JSON.parse(blogs);
    return lst;
}

$('#btnSave').click(function () {
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();

    if (editBlogId === null) {
        createBlog(title, author, content);
        successMessage("Saving Successful.");
    }
    else {
        updateBlog(editBlogId, title, author, content);
        successMessage("Updating Successful.");

        // Reset blog Id of Edit
        editBlogId = null;
    }

    clearControls();
    getBlogTable();
});

function clearControls() {
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
    $('#txtTitle').focus();
}

function getBlogTable() {
    const lst = getBlogs();
    let count = 0;
    let htmlRows = '';
    lst.forEach(item => {
        const htmlRow = `
       <tr>
            <td>
                <button type="button" class="btn btn-warning" onclick="editBlog('${item.id}')">Edit</button>
                <button type="button" class="btn btn-danger" onclick="deleteButtonClick('${item.id}')">Delete</button>
            </td>
            <td>${++count}</td>
            <td>${item.title}</td>
            <td>${item.author}</td>
            <td>${item.content}</td>
       </tr>
       `;

        htmlRows += htmlRow;
    });

    $('#tbody').html(htmlRows);
}

function editBlog(id) {
    let lst = getBlogs();

    const items = lst.filter(x => x.id === id);
    if (items.length == 0) {
        errorMessage("No data Found with Id: " + id);
        return;
    }

    const item = items[0];
    editBlogId = item.id;

    $('#txtTitle').val(item.title);
    $('#txtAuthor').val(item.author);
    $('#txtContent').val(item.content);
    $('#txtTitle').focus();
}

function deleteButtonClick(id) {
    Swal.fire({
        title: "Confirm",
        text: "Are you sure want to delete?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes"
    }).then((result) => {
        if (!result.isConfirmed) return;

        deleteBlog(id);
        successMessage("Deleting Successful");
        getBlogTable();
    });

    // Notiflix.Confirm.show(
    //     'Confirm',
    //     "Are you sure want to delete",
    //     'Yes',
    //     'No',
    //     function okCb() {
    //         deleteBlog(id);
    //         successMessage("Deleting Successful.");
    //         getBlogTable();
    //     },
    //     function cancelCb() {
    //         return;
    //     },
    //     {
    //     },
    // );


}