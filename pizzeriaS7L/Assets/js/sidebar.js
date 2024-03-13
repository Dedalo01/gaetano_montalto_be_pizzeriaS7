const menuToggle = document.querySelector(".menuToggle");
const sidebar = document.querySelector(".sidebar");

menuToggle.onclick = function () {
    menuToggle.classList.toggle("active");
    sidebar.classList.toggle("active");
}

const menuList = document.querySelectorAll(".menuList li")

function activeLink() {
    menuList.forEach(li => li.classList.remove("active"))
    this.classList.add("active")
}

menuList.forEach(li => li.addEventListener("click", activeLink))