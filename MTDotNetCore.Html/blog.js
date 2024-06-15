const tblBlog = "blogs";

console.log("Hello World from Console");

createBlog("test title", "test author", "test content");



function createBlog(title, author, content) {

    let requestModel = {
        title: title,
        author: author,
        content: content
    };

    let lst = [];
    let blogs = localStorage.getItem(tblBlog);
    console.log("blogs: " + blogs);
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    lst.push(requestModel);

    const jsonList = JSON.stringify(lst);

    localStorage.setItem(tblBlog, jsonList);
    console.log(jsonList);
}