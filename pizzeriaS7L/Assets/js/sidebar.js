const menuToggle = document.querySelector(".menuToggle");
const sidebar = document.querySelector(".sidebar");


menuToggle.onclick = function () {
    menuToggle.classList.toggle("active");
    sidebar.classList.toggle("active");
}

function activeLink(link) {
    link.classList.remove("active");
    const href = link.querySelector("a").getAttribute("href");

    if (currentUrl.includes(href)) {
        link.classList.add("active");
    }
}

document.addEventListener("DOMContentLoaded", function () {
    const currentUrl = window.location.href;
    
    const menuList = document.querySelectorAll(".menuList li")
    menuList.forEach(function (link) {
        link.classList.remove("active");

        const href = link.querySelector("a").getAttribute("href");
        console.log(href)
        if (currentUrl.endsWith(href)) {
            link.classList.add("active");
        }
    });
});