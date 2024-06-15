const tblBlog = "blogs";

console.log("Hello World from Console");

readBlog();
// createBlog("test title", "test author", "test content");
updateBlog("800343db-584d-4a43-90bb-4ce39cbdb95d", "updated title", "updated author", "updated content");


function readBlog(){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
}

function createBlog(title, author, content) {

    let requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content
    };

    let lst = [];
    let blogs = localStorage.getItem(tblBlog);
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    lst.push(requestModel);

    const jsonList = JSON.stringify(lst);

    localStorage.setItem(tblBlog, jsonList);
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

function updateBlog(id, UpdateTitle, updateAuthor, updateContent){
    const blogs = localStorage.getItem(tblBlog);
    if(blogs === null){
        console.log("There is no data in the database.");
        return;
    }
    
    let lst = JSON.parse(blogs);
    let items = lst.filter(x=> x.id === id);
    if(items.length < 1){
        console.log("No data found with Id: " + id);
        return;
    }

    let updateItem = items[0];
    updateItem.title = UpdateTitle;
    updateItem.author = updateAuthor;
    updateItem.content = updateContent;

    const index = lst.findIndex(x=> x.id === id);
    lst[index] = updateItem;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
    
}