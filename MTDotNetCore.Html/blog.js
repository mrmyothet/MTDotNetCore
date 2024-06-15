const tblBlog = "blogs";

console.log("Hello World from Console");

readBlog();
// createBlog("test title", "test author", "test content");


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

