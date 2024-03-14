

document.addEventListener("DOMContentLoaded", function () {
    const menuToggle = document.querySelector(".menuToggle");
    const sidebar = document.querySelector(".sidebar");

    menuToggle.onclick = function () {
        menuToggle.classList.toggle("active");
        sidebar.classList.toggle("active");
        // Salva stato sidebar quando viene cliccato il toggle
        saveSidebarState();
    }

    // Ripristina stato sidebar quando viene caricata pagina
    restoreSidebarState();

    const currentUrl = window.location.href;

    const menuList = document.querySelectorAll(".menuList li")

    if (menuList) {
        menuList.forEach(function (link) {
            link.classList.remove("active");

            const anchor = link.querySelector("a")
            if (anchor) {
                const href = anchor.getAttribute("href");
                console.log(href)
                if (currentUrl.endsWith(href)) {
                    link.classList.add("active");
                }
            }
        });

    }

    // Salva stato sidebar nel session storage
    function saveSidebarState() {
        const isSidebarOpen = sidebar.classList.contains("active");
        sessionStorage.setItem("sidebarState", isSidebarOpen ? "open" : "closed");
        console.log(sessionStorage.getItem("sidebarState"));
    }

    // Funzione per ripristinare lo stato della sidebar dal session storage
    function restoreSidebarState() {
        const sidebarState = sessionStorage.getItem("sidebarState");
        if (sidebarState === "open") {
            sidebar.classList.add("active");
            menuToggle.classList.add("active");
            console.log(sessionStorage.getItem("sidebarState"));
        }
    };
});