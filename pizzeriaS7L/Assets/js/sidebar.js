


document.addEventListener("DOMContentLoaded", function () {
    const menuToggle = document.querySelector(".menuToggle");
    const sidebar = document.querySelector(".sidebar");

    menuToggle.onclick = function () {
        menuToggle.classList.toggle("active");
        sidebar.classList.toggle("active");
    }


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